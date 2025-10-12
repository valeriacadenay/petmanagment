# 🐶 Veterinary Management System

Veterinary Management System es una aplicación desarrollada en C# (.NET 8) con el propósito de gestionar los servicios veterinarios, incluyendo pacientes (mascotas), veterinarios, tipos de servicio y citas.
El sistema permite registrar, visualizar, actualizar y eliminar información de manera estructurada y controlada.

---  
## 🧩 Características principales

- 📋 Registro de pacientes (mascotas) con sus datos básicos.

- 🧑‍⚕️ Gestión de veterinarios (nombre, especialidad, contacto, etc.).

- 💉 Registro de servicios veterinarios (consulta, cirugía, vacunación, baño, etc.).

- 🕒 Creación de citas con vínculo entre mascota, veterinario y tipo de servicio.

- 💾 Almacenamiento temporal en memoria (listas o repositorios).

- 🧱 Arquitectura basada en capas para mantener una estructura ordenada y escalable.
  
---
## 🧱 Estructura del proyecto

VeterinaryManagement/
│
├── Models/
│   ├── Patient.cs
│   ├── Veterinary.cs
│   ├── ServiceType.cs
│   └── ServiceVeterinary.cs
│
├── Repositories/
│   ├── IPatientRepository.cs
│   ├── IVeterinaryRepository.cs
│   ├── IServiceRepository.cs
│   └── Implementations/
│       ├── PatientRepository.cs
│       ├── VeterinaryRepository.cs
│       └── ServiceRepository.cs
│
├── Services/
│   ├── PatientService.cs
│   ├── VeterinaryService.cs
│   └── ServiceVeterinaryService.cs
│
├── Program.cs
└── README.md
