# 🐶 Veterinary Management System

Veterinary Management System is an application developed in C# (.NET 8) for the purpose of managing veterinary services, including patients (pets), veterinarians, types of services, and appointments.
The system allows information to be recorded, viewed, updated, and deleted in a structured and controlled manner.

---  
## 🧩 Main features

- 📋 Registration of patients (pets) with their basic details.

- 🧑‍⚕️ Management of veterinarians (name, specialty, contact details, etc.).

- 💉 Registration of veterinary services (consultation, surgery, vaccination, bathing, etc.).

- 🕒 Creation of appointments with links between pet, veterinarian, and type of service.

- 💾 Temporary storage in memory (lists or repositories).

- 🧱 Layer-based architecture to maintain an orderly and scalable structure.

  
---
## 🧱 Estructura del proyecto

```bash
VeterinaryManagement/
│
├── Data/
│   └── Database.cs
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
│   ├── PatientRepository.cs
│   ├── VeterinaryRepository.cs
│   └── ServiceRepository.cs
│
├── Services/
│   ├── PatientService.cs
│   ├── OwnerService.cs
│   ├── VeterinaryService.cs
│   └── ServiceVeterinaryService.cs
├── Menus/
│   ├── ClientMenu.cs
│   ├── MainMenu.cs
│   ├── PAtientMenu.cs
│   ├── UpdateOWnerMenu.cs
│   ├── UpdatePetMenu.cs
│   └── ServiceVeterinaryMenu.cs
│
├── Program.cs
└── README.md

```
## 🧩 How to Run

Follow these steps to run the project correctly from your local environment:

✅ Prerequisites


Have .NET 8.0 SDK or higher installed.
👉 You can verify this by running the following in the terminal:

```bash
dotnet --version
```

- A compatible editor, such as Visual Studio, Visual Studio Code, or rider.

- Clone this repository to your computer https://github.com/valeriacadenay/petmanagment.git.

-  Run the project

Open a terminal in the project's root folder:

 ```bash
cd petmanagement
```

 ```bash
- dotnet run --framework net8.0
```


## 👩‍💻 Author
- Valeria Cadena Yance 
- Clan: Caiman


