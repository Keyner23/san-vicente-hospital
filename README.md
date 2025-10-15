# San Vicente Hospital - Console App

Overview
--------
This is a .NET console application that simulates a simple management system for a clinic (San Vicente). The system allows you to:

- Register patients and doctors.
- List patients and doctors.
- Register medical appointments, view appointments and change their status.
- Basic validations: a patient or doctor cannot have more than one assigned appointment; patient emails must contain `@`.
- Send appointment confirmation emails via SMTP. If SMTP is not configured, the app saves a `.eml` file as a fallback in the `emails/` folder.

Features (what the system does)
--------------------------------
- Register Patients (name, document, phone, email, age)
- Register Doctors (name, document, phone, email, specialty)
- List Patients and Doctors
- Register medical Appointments (linking a patient and a doctor)
	- When creating an appointment the system asks for the patient document to identify the patient.
- Show all Appointments, show appointments by patient or by doctor
- Edit appointment status (Assigned, Attended, Cancelled)
- Business rules / validations:
	- A patient cannot have more than one active appointment at a time.
	- A doctor cannot have more than one active appointment at a time.
	- Patient email must contain `@` when registering.
	- The menu-driven console interface guides the user through operations.

Prerequisites
-------------
- .NET SDK 8.0 or higher installed
	- Verify with:
		```bash
		dotnet --version
		```
- (Optional) SMTP account if you want real email delivery (Gmail, SendGrid, etc.).
	- The project includes an `EmailService` using MailKit (package added). If you plan to send real emails, configure SMTP environment variables before running.

Getting the code (clone)
-------------------------
1. Clone the repository and change to the project folder:

```bash
git clone <repo-url>
cd san-vicente-hospital
```

Build and dependencies
----------------------
2. Restore packages and build the project:

```bash
dotnet build
```

3. (Optional) If you want to send real emails, set SMTP environment variables in your shell (example below). If you don't set them, the app will keep focusing on core functionality and may save an .eml file on failure.

Example SMTP environment variables (Gmail with App Password)
```bash
export SMTP_HOST=smtp.gmail.com
export SMTP_PORT=587
export SMTP_USER=your.account@gmail.com
export SMTP_PASS=YOUR_APP_PASSWORD
export SMTP_ENABLE_SSL=true
```

Important Gmail notes:
- If your Google account has 2FA enabled, create an App Password at https://myaccount.google.com/security → App passwords and use it as `SMTP_PASS`.
- Google may block sign-in attempts from unknown clients; App Passwords are the supported way.

Run the application
-------------------
4. Run the interactive console app:

```bash
dotnet run --project ./san-vicente-hospital.csproj
```

5. Use the menu options to exercise the system:
- 1: Register a patient
- 2: View patients
- 3: Register a doctor
- 4: View doctors
- 5: View doctors by specialty
- 6: Register an appointment (will ask for patient document and doctor name)
- 7: View all appointments
- 8: Change appointment status
- 9: View appointments by patient document
- 10: View appointments by doctor name

How the appointment flow works
-----------------------------
- When you register an appointment the app will:
	- Ask for the doctor name and verify the doctor exists.
	- Ask for the patient's document and verify the patient exists.
	- Validate that neither the patient nor the doctor already have an assigned appointment.
	- Create the appointment and store it in memory (the app currently uses an in-memory list as a simple database replacement).
	- Attempt to send a confirmation email using `EmailService` if SMTP variables are defined. If sending fails or SMTP is not configured, the app may save an `.eml` file in the `emails/` folder for inspection.

Notes about persistence and databases
-----------------------------------
- Currently the project uses in-memory lists (`Db/Database.cs`) for patients, doctors and appointments. This means data is not persisted between runs.
- If you want persistence, we can add a simple file-based storage (JSON) or integrate a relational DB (SQLite, SQL Server). I can help add that.

Developer notes — "Be a codernnn"
--------------------------------
- This repo is a learning / prototype project. Tidy up, add unit tests, and refactor for production readiness when you expand it.
- If you want, I can:
	- Add unit tests for business rules
	- Add persistent storage (SQLite)
	- Harden input validation and error handling
	- Make email sending optional or backgrounded

Troubleshooting
---------------
- If the app prints email or SMTP errors, check the environment vars and credentials.
- If you see authentication errors with Gmail, ensure you used an App Password and that SMTP_PORT and SMTP_ENABLE_SSL are correct.

Contact / Next steps
--------------------
Tell me what you'd like next: enable full email delivery with MailKit and a test send, add persistence (SQLite), or implement unit tests and CI. I'm ready to implement the next step.

Prerequisites
-------------
- .NET SDK 8.0 or higher
	- Verify with:
		```bash
		dotnet --version
		```
Clone, configure and run
------------------------
1. Clone the repository:

```bash
git clone <repo-url>
cd san-vicente-hospital
```

2. Restore packages and build:

```bash
dotnet build
```

3. Run the application:

```bash
dotnet run --project ./san-vicente-hospital.csproj
```

The application is interactive. Use the menu to:
- Register a patient (option 1)
- Register a doctor (option 3)
- Register an appointment (option 6) — when creating an appointment the app will request the patient's document number.

Note about email sending
------------------------
Email sending and SMTP configuration are not yet fully implemented in the project. There is a placeholder `EmailService` and code paths prepared to send confirmations, but a production-ready SMTP configuration and testing are pending. For now, the app focuses on the core clinic flows (patients, doctors, appointments). If you want to enable email sending later, see the previous README history or ask me and I will help configure SMTP (Gmail/SendGrid) and test a real send.
Recommendations and improvements
-------------------------------
- For production use a dedicated email provider (SendGrid, Mailgun, etc.) and store credentials securely (Key Vault, Secrets Manager or CI/CD env vars).
- Validate email format more strictly (regex or a validation library).
- Send emails asynchronously in background workers to avoid blocking the console UX.
- Add unit tests for business rules (appointment duplication, email validation, etc.).

Contact
-------
If you want, I can run a test send from this environment after you export SMTP variables in your terminal (do not paste passwords in chat). I can also rework the email logic or make the send fully asynchronous.