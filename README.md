# Reserva sala de reuniones con Netcore 3.0
Pasos para implementar prueba técnica

### Base de datos:
En la solución ScriptDB hay un archivo llamado script.sql, antes de iniciar la aplicación debe correr el script.

### Iniciar aplicaciones 
Se necesita instalar el sdk y el runtime de netcore 3.0 para levantar el proyecto
La aplicación cuenta de 2 partes un api rest y una aplicación web.
1.	Clonar el repositorio
2.	Abrir el archivo .sln con visual studio
3.	Cuando se haya abierto, dar clic derecho a la solución y seleccionar proyectos inicios múltiples y seleccionar la aplicación .API y .WEB.
4.	Iniciar sesión con cualquiera de los siguientes usuarios 
* **Nickname** - **Password** - **Rol**
* Perdomo24 - *Abc123..* - *Administrador*
* Usuario1 - *Abc123..* - *Usuario Basico*
		
### ¿Que hace este ejemplo de reserva de salas?
**Administrador**
1.	Crud para sala de reuniones
2.	Y manejo de calendarios

**Usuario básico**
1.	Ver disponibilidad de calendario
2.	Crear y cancelar eventos en el calendario

### tecnologías utilizadas
* Netcore 3.0
* Contiene una Api rest.
* Contiene una aplicación web que consume el api
* Jwt para la autenticación y autorización de los controladores y acciones en el api. 
* SQL server para la base de datos


