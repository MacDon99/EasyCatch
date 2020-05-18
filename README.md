# EasyCatch
Project for classes - Fishing Shop ASP.NET + React

For the first x commits I used different git account - RybczanSodu, idk why.

If you want to run the API project, type dotnet run in EasyCatch.Api/EasyCatch.Web

**Using:**
```
      Controllers:
                Authentication:
                               localhost:port/api/authentication/register - post
                                                                      - json schema:
                                                                      {
                                                                        "login": "login",
                                                                        "password": "Password220@",
                                                                        "email": "mail@mail.pl",
                                                                        "name": "Name",
                                                                        "surname": "Surname"
                                                                      }
                               localhost:port/api/authentication/login - post
                                                                   - json schema:
                                                                   {
                                                                   "login": "login",
                                                                   "password": "password"
                                                                   }                                              
                Order:
                      localhost:port/api/order/createorder - no json needed
                      localhost:port/api/order/addProduct - patch to add product to order
                                                      - json schema: 
                                                      {
                                                        "orderId": "09e1bc7d-8809-4b5d-b43c-5d9051f57dc7",
                                                        "productId": "ccc42f26-b3a8-4656-beef-71e8d4baeaca"
                                                      }
                      localhost:port/api/order/orderId - get to get an order info
                                                   - no json needed
                      localhost:port/api/order/setaddress - patch to set order address
                                                      - json schema:
                                                      {
                                                        "street": "street",
                                                        "housenumber": "housenumber",
                                                        "postcode": "postcode",
                                                        "city", "city"
                                                      }
                      localhost:port/api/order/orderId - delete to delete an order
                                                   - as OrderId type actual orderId
                Product:
                      localhost:port/api/product/add - post to create a new product
                                                 - json schema: 
                                                 {
                                                    "name": "ProductName",
                                                    "price": 2.5,
                                                    "description": "ProductDescription",
                                                    "quantity": 15
                                                  }
                                                  - also file needed as a Product photo
                      localhost:port/api/product/productId - delete to delete a product
                                                     - as productId type actual productId
                      localhost:port/api/product/productId - get to get a product
                                                     - as productId type actual productId

```
