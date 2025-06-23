<a name="br1"></a> 

# **Desafío: API de Verificación de Descuento de Producto**

Tu tarea es crear una API en C# que permita a los clientes verificar si son elegibles para un descuento en un producto según ciertas reglas de negocio.

Reglas de negocio:

* Si el cliente es un miembro gold, recibe un descuento del 20% en todos los productos.
* Si el producto es electrónico y cuesta más de $1000, independientemente del estado de membresía del cliente, recibe un descuento del 10%.
* Si el producto es un libro, independientemente del estado de membresía del cliente, no se aplica ningún descuento.

Tu API debe tener los siguientes puntos finales:

1\. **POST /api/discount/check**: Este punto final debe aceptar una solicitud JSON con la
 siguiente información:
* **membershipStatus**: El estado de membresía del cliente (por ejemplo, "gold", "silver", "regular").
* **productType**: El tipo de producto (por ejemplo, "electronic", "book", "other").
* **productPrice**: El precio del producto.

La API debe determinar si se aplica un descuento según las reglas de negocio y devolver una respuesta JSON que incluya el precio original y el precio con descuento, si corresponde.

2\. **GET /api/membership/status**: Este punto final debe devolver una lista de los estados de membresía disponibles.

3\. **GET /api/product/types**: Este punto final debe devolver una lista de los tipos de producto disponibles.

Tu API debe ser segura y estar bien documentada. Puedes utilizar ASP.NET Core para desarrollar la API y Entity Framework Core para interactuar con una base de datos si es necesario. Tu API debe seguir una arquitectura basada en **DDD (Domain-Driven Design)** y **CQRS (Command Query Responsibility Segregation)** para garantizar escalabilidad y mantenibilidad
