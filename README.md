# 🏥 San Vicente Hospital - Console App

## 📖 Overview
**San Vicente Hospital** is a console application built with **.NET 8.0**, designed to simulate a simple clinic management system.  
It allows users to register patients, doctors, and appointments, apply basic business rules, and optionally send confirmation emails.

### ✨ Main Features
- Register and list **Patients** (name, document, phone, email, age)
- Register and list **Doctors** (name, document, phone, email, specialty)
- Create and manage **Appointments** linking patients and doctors
- Change appointment status (**Assigned**, **Attended**, **Cancelled**)
- Validations:
  - A patient or doctor cannot have more than one active appointment.
  - Patient email must include `@`.
- Send appointment confirmation emails via **SMTP**

---

## 🧰 Prerequisites
Before running the project, make sure you have:

- **.NET SDK 8.0 or higher**  
  Check installation:
  ```bash
  dotnet --version
    ```

## ⚙️ Installation & Setup

1. Clone the repository
```bash
git clone https://github.com/Keyner23/san-vicente-hospital.git
cd san-vicente-hospital
```

2. Restore dependencies and build
```bash
dotnet build
```

3. Configure SMTP for email sending
```bash
export SMTP_HOST=smtp.gmail.com
export SMTP_PORT=587
export SMTP_USER=your.email@gmail.com
export SMTP_PASS=YOUR_APP_PASSWORD
export SMTP_ENABLE_SSL=true
```

4. Run the application
```bash
   dotnet run
```

## 💻 How It Works
Once running, the console menu will guide you through operations such as:

- Registering patients and doctors

- Viewing all registered users

- Creating appointments by linking a patient and a doctor

- Checking or editing appointment status

All data is stored in memory during runtime.

## 🪪 Author & Info

Language: C# (.NET 8.0)

Type: Console Application

Purpose: Educational / Practice Project

Author: Keyner Andres Barrios Ochoa - Caiman - keinerba.ochoa@gmail.com.