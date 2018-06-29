CREATE DATABASE CTUCareDB
GO

USE CTUCareDB
GO

CREATE TABLE MedicalAid
(
ID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
Name VARCHAR(20) NOT NULL,
Email VARCHAR(40) NOT NULL
);

CREATE TABLE Patient
(
ID INT PRIMARY KEY NOT NULL IDENTITY (1,1),  /*ID Will be used as the file number*/
Name VARCHAR(20) NOT NULL,
Surname VARCHAR(20) NOT NULL,
Cell VARCHAR(10) NOT NULL,
IDNumber VARCHAR(13) NOT NULL,
MedicalAidID INT REFERENCES MedicalAid(ID),
MedicalAidNo VARCHAR(10),
AccountNumber INT NOT NULL,
[Address] VARCHAR(50) NOT NULL
);

CREATE TABLE [User]
(
ID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
Username VARCHAR(20) NOT NULL,
[Password] VARCHAR(20) NOT NULL,
IsUserAdmin INT NOT NULL /* 1 is true 2 is false */
);

CREATE TABLE Doctor
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Name VARCHAR(20) NOT NULL,
ConsultationFee MONEY NOT NULL
);

CREATE TABLE Medicine
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Name VARCHAR(30) NOT NULL,
Price MONEY NOT NULL
);

CREATE TABLE EntryDate
(
ID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
PatientID INT REFERENCES Patient(ID),
DateEntered DATETIME
);

CREATE TABLE AdministeredMedicine
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
PatientID INT REFERENCES Patient(ID),
MedicineID INT REFERENCES Medicine(ID),
DateAdministeredID INT REFERENCES EntryDate(ID)
);

CREATE TABLE [Procedure]
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Name VARCHAR(30) NOT NULL,
Cost MONEY NOT NULL
);

CREATE TABLE DispatchDate /*Doing this so that dispatch dates are available to both adminPro and appointment */
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
PatientID INT REFERENCES Patient(ID),
DispatchDate DATE
);



CREATE TABLE Appointment
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
PatientID INT REFERENCES Patient(ID),
IntakeDateID INT REFERENCES EntryDate(ID),
DispatchDateID INT REFERENCES DispatchDate(ID),
DrID INT REFERENCES Doctor(ID),
);


CREATE TABLE AdministeredProcedure
(
ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
PatientID INT REFERENCES Patient(ID),
ProcedureID INT REFERENCES [Procedure](ID),
EntryDateID INT REFERENCES EntryDate(ID),
);

INSERT INTO [User](Username, [Password], IsUserAdmin) VALUES
('Admin', 'admin', 1),
('User', 'user', 2);

INSERT INTO [Procedure] (Name, Cost) VALUES
('Heart Transplant', 150000),
('Knee Reconstruction', 50000),
('Mole Removal', 10000);

INSERT INTO MedicalAid(Name, Email) VALUES
('Discovery', 'discovery@discover.co.za'),
('Momentum', 'momentum@momentum.co.za');

INSERT INTO Patient(Name, Surname, Cell, IDNumber, MedicalAidID, MedicalAidNo, AccountNumber, [Address]) VALUES
('Daniel', 'Jordaan', '0800000000', '9700000000000', 1, '1010', 111, '21 Bla Street'),
('Jarrod', 'Venter', '0834360737', '9306045062082', 2, '1030', 222, '22 Bla Street');

INSERT INTO Doctor(Name, ConsultationFee) VALUES
('Dr Schmidt', 500),
('Dr Vlok', 750);


