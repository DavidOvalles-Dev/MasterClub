ClubMaster 🏅⚽
Descripción:
Este proyecto es un sistema de gestión para clubes deportivos, diseñado para administrar miembros, actividades, eventos y otros aspectos relacionados con la organización de un club. La aplicación permite la creación, edición y eliminación de miembros, la planificación de actividades y eventos, y la gestión de pagos y reportes.

Tecnologías utilizadas:

Frontend: HTML, CSS, Bootstrap 💻
Backend: C# con ASP.NET Core 🖥️
Base de Datos: SQL Server 🗄️
Características ✨
👤 Gestión de miembros: registro, actualización y consulta de información.
🏋️‍♂️ Creación y administración de actividades deportivas y eventos.
💳 Gestión de pagos: registro y consulta de transacciones.
📊 Generación de reportes detallados de asistencia y pagos.
🎨 Interfaz intuitiva y fácil de usar.
🚀 Instalación
Sigue estos pasos para instalar y ejecutar el proyecto en tu máquina local:

Clona este repositorio:

bash
Copy code
git clone https://github.com/DOOM-EXE/ClubMaster.git
Navega al directorio del proyecto:

bash
Copy code
cd ClubMaster
Abre el proyecto en Visual Studio o tu editor de C# preferido.

Configura la base de datos:
Asegúrate de tener SQL Server configurado en tu entorno y ajusta la cadena de conexión en el archivo appsettings.json:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ClubDB;Trusted_Connection=True;"
}
Restaura los paquetes NuGet necesarios:

bash
Copy code
dotnet restore
Ejecuta la aplicación:

bash
Copy code
dotnet run
💡 Uso
Al ejecutar la aplicación, podrás acceder a la interfaz de usuario en tu navegador 🌐.
Gestiona la información de miembros, actividades, eventos y pagos 📋, y visualiza los reportes generados 📑.
Licencia 📄
Este proyecto está bajo la licencia MIT.

