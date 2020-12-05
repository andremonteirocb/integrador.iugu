# IUGU [![Build Status](https://secure.travis-ci.org/morrisjs/morris.js.png?branch=master)](http://travis-ci.org/morrisjs/morris.js)
.NET Class Library for integration with IUGU API <br />
.Net Core 3.0

## Configurações
### appsettings.json
```c#
  "IuguClientSettings": {
    "ApiKey": "chave_iugu"
  },
  ```
  
## Fatura
### Criar Fatura
```c#
  public async Task CriarFatura()
  {
      var addressModel = new AddressModel
      {
          ZipCode = "cep",
          District = "bairro",
          State = "estado",
          Street = "endereco",
          Number = "numero",
          City = "cidade",
          Country = "pais"
      };
      var payer = new PayerModel
      {
          CpfOrCnpj = "cpf_cliente",
          Address = addressModel
      };

      InvoiceModel invoice;
      var customVariables = new List<CustomVariables>
      {
          new CustomVariables { name = "TaxaIugu", value = "2,50" },
          new CustomVariables { name = "OutraTaxa", value = "1,00" },
          new CustomVariables { name = "Origem", value = "seu_sistema" }
      };
      var earlyPaymentDiscounts = new List<EarlyPaymentDiscounts>
      {
          new EarlyPaymentDiscounts { days = 10, percent = "8.2" },
          new EarlyPaymentDiscounts { days = 5, percent = "5" }
      };
      
      var invoiceDate = DateTime.Now.AddDays(2);
      var customer = new CustomerRequestMessage
      {
          Email = "email_cliente",
          Name = "nome_cliente",
          CpfOrCnpj = "cpf_cliente",
          CustomVariables = customVariables
      };

      using (var apiInvoice = new Invoice())
      using (var apiCustomer = new Customer())
      {
          var customerResponse = await apiCustomer.CreateAsync(customer, null).ConfigureAwait(false);
          var invoiceItems = new[] { new Item { description = "descricao_cobranca", price_cents = 35000, quantity = 1, price = "350,00" } };
          invoice = await apiInvoice.CreateAsync("email_cliente", invoiceDate, invoiceItems, customer_id: customerResponse.id, custom_variables: customVariables, payer: _payer,
                    early_payment_discount: true, early_payment_discounts: earlyPaymentDiscounts)
                                          .ConfigureAwait(false);
      };
  }
```

### Obter Fatura por id
```c#
  public async Task Consultar_Fatura()
  {
      InvoiceModel invoice = null;
      using (var apiInvoice = new Invoice())
      {
          try
          {
              invoice = await apiInvoice.GetAsync("fatura_id").ConfigureAwait(false);
          }
          catch (Exception ex)
          {
              var errors = await ErrorResponseMessage.BuildAsync(ex.Message).ConfigureAwait(false);
          }
      };
  }
```

### Cancelar Fatura
```c#
  public async Task Cancelar_Fatura()
  {
      InvoiceModel invoice = null
      using (var apiInvoice = new Invoice())
      {
          try
          {
              invoice = await apiInvoice.CancelAsync("fatura_id").ConfigureAwait(false);
          }
          catch (Exception ex)
          {
              var errors = await ErrorResponseMessage.BuildAsync(ex.Message).ConfigureAwait(false);
          }
      };
  }
```

### Listar faturas
```c#
  public async Task Listar_Todas_Faturas()
  {
      PaggedResponseMessage<InvoiceModel> invoices;
      using (var apiInvoice = new Invoice())
      {
          var filter = new QueryStringFilter() { MaxResults = 10 };
          invoices = await apiInvoice.GetAllAsync(null, filter).ConfigureAwait(false);
      };
  }
```

### Enviar fatura por e-mail
```c#
  public async Task Enviar_Por_Email()
  {
      InvoiceModel resendInvoiceModel = null;
      using (var apiInvoice = new Invoice())
      {
          resendInvoiceModel = await apiInvoice.ResendInvoiceMail("resendInvoiceId").ConfigureAwait(false);
      };
  }
```

## Cliente
### Criar cliente
```c#
  public async Task Criar_cliente()
  {
      var custom = new List<CustomVariables>();
      custom.Add(new CustomVariables { name = "Origem", value = "seu_sistema" });

      CustomerModel myClient;
      var customer = new CustomerRequestMessage
      {
          Email = "email_cliente",
          Name = "nome_cliente",
          CpfOrCnpj = "cpf_cliente",
          CustomVariables = custom
      };

      using (var apiClient = new Customer())
      {
          myClient = await apiClient.CreateAsync(customer, null).ConfigureAwait(false);
      };
  }
```

### Obter cliente por id
```c#
  public async Task BuscarCliente_Por_Id()
  {
    CustomerModel myClient = null;
    using (var apiClient = new Customer())
    {
        try
        {
            myClient = await apiClient.GetAsync("cliente_id").ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            var errors = await ErrorResponseMessage.BuildAsync(ex.Message).ConfigureAwait(false);
        }
    };
  }
```

### Obter todos os clientes
```c#
  public async Task List_Todos_Clientes()
  {
      CustomersModel myClients;
      using (var apiClient = new Customer())
      {
          myClients = await apiClient.GetAsync().ConfigureAwait(false);
      };
  }
```

### Obter faturas do cliente
```c#
  public async Task Listar_Todas_Faturas_Cliente()
  {
      PaggedResponseMessage<InvoiceModel> invoices;
      using (var apiInvoice = new Invoice())
      {
          var filter = new QueryStringFilter() { MaxResults = 10, AditionalParameters = $"customer_id={customer_id}" };
          invoices = await apiInvoice.GetAllAsync(null, filter).ConfigureAwait(false);
      };
  }
```

### Deletar cliente
```c#
  public async Task DeleteCliente()
  {
      CustomerModel myClient;
      using (var apiClient = new Customer())
      {
          myClient = await apiClient.DeleteAsync("cliente_id").ConfigureAwait(false);
      };
  }
```
