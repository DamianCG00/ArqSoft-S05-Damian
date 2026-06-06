
##  Información del Estudiante

* **Nombre:** Marco Damian
* **Matrícula:** SW2509029
* **Grupo:** 3B
* **Cuatrimestre:** Segundo Trimestre
* **Carrera:** TSU en Desarrollo e Innovación de Software
* **Profesor:** Jorge Javier Pedrozo Romero

---

#  Sistema de Gestión de Citas Médicas

Este proyecto es una **aplicación web MVC desarrollada en ASP.NET Core** que permite administrar información relacionada con pacientes, médicos y citas médicas.

El sistema facilita el registro y visualización de pacientes, médicos y citas, organizando la información mediante el patrón de arquitectura **Modelo-Vista-Controlador (MVC)** y garantizando la persistencia de datos mediante una arquitectura de **archivos planos (JSON)**.

---

##  Características

* Registro y gestión dinámica de pacientes.
* Registro y gestión de médicos especialistas.
* Administración y agendamiento de citas médicas.
* Organización estructurada mediante arquitectura MVC.
* Interfaz web responsiva desarrollada con Razor Views y Bootstrap.
* Lectura y escritura de datos en tiempo real utilizando `System.Text.Json`.

---

##  Cómo funciona el sistema

1. **Inicio de la aplicación:** El usuario accede al sistema desde el navegador a través del servidor local IIS Express.
2. **Gestión de pacientes:** Se visualizan y administran los datos en el módulo correspondiente.
3. **Gestión de médicos:** Se consultan los médicos con su especialidad y número de licencia.
4. **Gestión de citas:** Se programan citas asociando pacientes y médicos mediante formularios dinámicos.
5. **Controladores MVC:** Procesan las solicitudes (GET/POST), leen los archivos `.json` y retornan las vistas correspondientes.

---

##  Estructura del proyecto

```text
CitasApp/
├── Controllers/
│   ├── HomeController.cs
│   ├── PacienteController.cs
│   ├── MedicoController.cs
│   └── CitaController.cs
│
├── data/
│   ├── pacientes.json
│   ├── medicos.json
│   └── citas.json
│
├── Models/
│   ├── Paciente.cs
│   ├── Medico.cs
│   ├── Cita.cs
│   └── ErrorViewModel.cs
│
├── Views/
│   ├── Cita/
│   │   ├── Crear.cshtml
│   │   └── Index.cshtml
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Medico/
│   │   └── Index.cshtml
│   ├── Paciente/
│   │   └── Index.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
│
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   └── js/
│
├── Program.cs
├── appsettings.json
└── README.md
```

---
## Declaración de IA
En esta actividad use la IA (Gemmini) para poder entender de mejor manera el funcionamiento de los codigos, el uso correcto en as diapositivas,
e incluso la generación del mismo

Pese a que su suo fue continuo esto fue con la finalida de que pueda tener un mejor entendimiento de como es que funcionan todos estos codigos,
con la finalida de poder comprender su funicionamiento le eh pedido que genre fragmentos de IA para poder ver en accion como es que funcionan






























