# SchoolProject 📚🎓

**Descripción:**  
Este proyecto es un sistema de gestión para una escuela, diseñado para administrar estudiantes, profesores y otros aspectos relacionados con la gestión educativa. La aplicación permite la creación, edición y eliminación de estudiantes, la asignación de profesores a cursos y la gestión de la información académica.

**Tecnologías utilizadas:**  
- **Frontend:** HTML, CSS, Bootstrap 💻  
- **Backend:** C# con ASP.NET Core 🖥️  
- **Base de Datos:** SQL Server 🗄️

---

## Características ✨

- 👩‍🏫 Gestión de estudiantes y profesores.
- 📚 Creación y administración de cursos.
- 📊 Visualización de los detalles de cada estudiante y profesor.
- 🎨 Interfaz de usuario intuitiva y fácil de usar.

---

## 🚀 Instalación

Sigue estos pasos para instalar y ejecutar el proyecto en tu máquina local:

1. **Clona este repositorio**:
    ```bash
    git clone https://github.com/DOOM-EXE/SchoolProject.git
    ```

2. **Navega al directorio del proyecto**:
    ```bash
    cd SchoolProject
    ```

3. **Abre el proyecto** en Visual Studio o tu editor de C# preferido.

4. **Configura la base de datos**:  
   Asegúrate de tener SQL Server configurado en tu entorno y ajusta la cadena de conexión en el archivo `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=SchoolDB;Trusted_Connection=True;"
    }
    ```

5. **Restaura los paquetes NuGet** necesarios:
    ```bash
    dotnet restore
    ```

6. **Ejecuta la aplicación**:
    ```bash
    dotnet run
    ```

---

## 💡 Uso

- Al ejecutar la aplicación, podrás acceder a la interfaz de usuario en tu navegador 🌐.
- Gestiona la información de estudiantes, actividades y profesores 📋, y visualiza los detalles completos de cada entidad 📑.

---

## Licencia 📄

Este proyecto está bajo la licencia [MIT](LICENSE).

