<a name="br1"></a> 

# **Desafío: API de Gestión de Operaciones Mineras - Ming Company**

**Descripción:**

La empresa Ming Company requiere una API en ASP.NET Core para gestionar sus operaciones mineras. La API debe permitir registrar y eliminar operaciones mineras, cumpliendo reglas de negocio sencillas.

**Requisitos Técnicos:**

**1\. Modelo de Datos (Operation)**
* Id  : Obligatorio mayor a 0
* Title (nombre de la operación) mínimo **3 caracteres**, máximo **100 caracteres**.
* Description (descripción de la operación) Opcional, **máximo 250 caracteres** para evitar textos demasiado extensos
* Type (enum: Excavation, Transport, Maintenance, etc.) , debe ser un valor del enum.
* Date (fecha de la operación) Obligatorio, **no puede ser futura**
* Status (activo/inactivo)  solo acepte valores booleanos 

**2\. Reglas de Negocio:**
* No se pueden registrar operaciones con fecha futura.
* Solo se pueden eliminar operaciones si han sido completadas hace más de 30 días.

**3\. Endpoints REST en ASP.NET Core**
* POST /api/operations → Crear una operación nueva.
* DELETE /api/operations/{id} → Eliminar operación completada hace más de 30 días.
* GET /api/operations → Listar todas las operaciones.  

**Criterios de Evaluación**

1. Funcionalidad: La API debe permitir crear, listar y eliminar operaciones.   
2. Código Limpio: La estructura del código debe seguir buenas prácticas en 
ASP.NET Core.   
3. Arquitectura DDD (Domain-Driven Design) y CQRS (Command Query 
Responsibility Segregation) para garantizar escalabilidad y mantenimiento 
óptimo. 
4. **Documentar con Swagger OpenAPI**
