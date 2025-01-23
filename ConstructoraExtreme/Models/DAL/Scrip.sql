CREATE DATABASE ConstructoraDB;
USE ConstructoraDB;

-- Base tables
CREATE TABLE Users (
id INT PRIMARY KEY IDENTITY(1,1),
name VARCHAR(50) NOT NULL,
email VARCHAR(100) UNIQUE NOT NULL,
password VARCHAR(255) NOT NULL
);

CREATE TABLE Stores(
id INT PRIMARY KEY IDENTITY(1,1),
name VARCHAR(255) NOT NULL,
address VARCHAR(200) UNIQUE NOT NULL,
address_link VARCHAR(200) UNIQUE NOT NULL,
phone_number VARCHAR(255) NOT NULL,
nit VARCHAR(20) NOT NULL,
nrc VARCHAR(100) UNIQUE NOT NULL,
giro VARCHAR(100) UNIQUE NOT NULL,
user_id INT NOT NULL,
FOREIGN KEY (user_id) REFERENCES Users(id)
);

-- Catalog tables (referenced by persons table)
CREATE TABLE document_types_catalog(
id INT IDENTITY(1,1) PRIMARY KEY,
code VARCHAR(10) UNIQUE NOT NULL,
name VARCHAR(100) NOT NULL,
is_natural_person BIT NOT NULL,
active BIT DEFAULT 1,
created_at DATETIME DEFAULT GETDATE(),
);

CREATE TABLE departments_catalog(
id INT IDENTITY(1,1) PRIMARY KEY,
code varchar(2) UNIQUE NOT NULL,
name VARCHAR(100) NOT NULL
);

CREATE TABLE municipalities_catalog ( 
id INT IDENTITY(1,1) PRIMARY KEY,
code CHAR(2) NOT NULL,
department_id INTEGER NOT NULL,
name VARCHAR(100) NOT NULL,
FOREIGN KEY (department_id) REFERENCES departments_catalog(id)
);

CREATE TABLE economic_activities_catalog (
id INT IDENTITY(1,1) PRIMARY KEY,
code VARCHAR(10) UNIQUE NOT NULL,
description TEXT NOT NULL,
active BIT DEFAULT 1
);

-- Products and related tables
CREATE TABLE Products (
id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(100) NOT NULL,
description TEXT,
brand VARCHAR(50),
store_id INT NOT NULL,
FOREIGN KEY (store_id) REFERENCES Stores(id),
FOREIGN KEY (category_id) REFERENCES Category(id)
);

CREATE TABLE Prices (
id INT IDENTITY(1,1) PRIMARY KEY,
product_id INT NOT NULL,
daily_price DECIMAL(10, 2) NOT NULL,
monthly_price DECIMAL(10, 2) NOT NULL,
FOREIGN KEY (product_id) REFERENCES Products(id)
);

CREATE TABLE Inventory(
id INT IDENTITY(1,1) PRIMARY KEY,
product_id INT NOT NULL,
available_quantity INT NOT NULL,
store_id INT NOT NULL,
FOREIGN KEY (product_id) REFERENCES Products(id),
FOREIGN KEY (store_id) REFERENCES Stores(id)
);

-- Persons table (must be created after its referenced tables)
CREATE TABLE persons (
id INT IDENTITY(1,1) PRIMARY KEY,
document_type_id INTEGER NOT NULL,
document_number VARCHAR(50) NOT NULL,
store_id INT NOT NULL,
is_natural_person BIT NOT NULL,
first_name VARCHAR(100),
middle_name VARCHAR(100),
first_surname VARCHAR(100),
second_surname VARCHAR(100),
business_name VARCHAR(200),
trade_name VARCHAR(200),
nrc VARCHAR(20),
economic_activity_id INTEGER,
email VARCHAR(100) UNIQUE NOT NULL,
phone VARCHAR(20) NOT NULL,
country VARCHAR(100) NOT NULL DEFAULT 'El Salvador',
department_id INTEGER NOT NULL,
municipality_id INTEGER NOT NULL,
address_details TEXT NOT NULL,
active BIT DEFAULT 1,
created_at DATETIME DEFAULT GETDATE(),
updated_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (document_type_id) REFERENCES document_types_catalog(id),
FOREIGN KEY (economic_activity_id) REFERENCES economic_activities_catalog(id),
FOREIGN KEY (department_id) REFERENCES departments_catalog(id),
FOREIGN KEY (municipality_id) REFERENCES municipalities_catalog(id),
CONSTRAINT uq_documento UNIQUE(document_type_id, document_number),
FOREIGN KEY (store_id) REFERENCES Stores(id)
);

-- Tables that reference persons (must be created after persons table)
CREATE TABLE person_references (
id INT IDENTITY(1,1) PRIMARY KEY,
store_id INT NOT NULL,
person_id INTEGER NOT NULL,
first_name VARCHAR(100) NOT NULL,
middle_name VARCHAR(100),
first_surname VARCHAR(100) NOT NULL,
second_surname VARCHAR(100),
phone VARCHAR(20) NOT NULL,
created_at DATETIME DEFAULT GETDATE(),
updated_at DATETIME DEFAULT GETDATE(),
active BIT DEFAULT 1,
FOREIGN KEY (person_id) REFERENCES persons(id),
FOREIGN KEY (store_id) REFERENCES Stores(id)  
);

CREATE TABLE images --SIN CLASE DAL 
(
id INT IDENTITY(1,1) PRIMARY KEY,
store_id INT NOT NULL,
person_id INTEGER NOT NULL,
file_data VARBINARY(MAX) NOT NULL,
creation_date DATETIME DEFAULT GETDATE(),
FOREIGN KEY (person_id) REFERENCES persons(id),
FOREIGN KEY (store_id) REFERENCES Stores(id)
);

-- Rental system tables
CREATE TABLE rentals(
id INT IDENTITY(1,1) PRIMARY KEY,
store_id INT NOT NULL,
person_id INT NOT NULL,
total_amount DECIMAL(10, 2) NOT NULL,
start_date DATE NOT NULL,
end_date DATE NOT NULL,
status VARCHAR(20) DEFAULT 'ACTIVE' CHECK (status IN ('ACTIVE', 'COMPLETED', 'CANCELLED')),
created_at DATETIME DEFAULT GETDATE(),
updated_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (store_id) REFERENCES Stores(id),
FOREIGN KEY (person_id) REFERENCES persons(id)
);

CREATE TABLE rental_details(
id INT IDENTITY(1,1) PRIMARY KEY,
rental_id INT NOT NULL,
product_id INT NOT NULL,
quantity INT NOT NULL,
daily_price DECIMAL(10, 2) NOT NULL,
rental_days INT NOT NULL,
subtotal DECIMAL(10, 2) NOT NULL,
created_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (rental_id) REFERENCES rentals(id),
FOREIGN KEY (product_id) REFERENCES Products(id)
);

-- Payment system tables
CREATE TABLE rental_payments (
id INT IDENTITY(1,1) PRIMARY KEY,
rental_id INT NOT NULL,
total_amount DECIMAL(10, 2) NOT NULL,
pending_amount DECIMAL(10, 2) NOT NULL,
advance_payment DECIMAL(10, 2) DEFAULT 0,
payment_status VARCHAR(20) DEFAULT 'PENDING'
CHECK (payment_status IN ('PENDING', 'PARTIALLY_PAID', 'PAID', 'OVERDUE')),
due_date DATE NOT NULL,
created_at DATETIME DEFAULT GETDATE(),
updated_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (rental_id) REFERENCES rentals(id) 
);

CREATE TABLE payment_history (
id INT IDENTITY(1,1) PRIMARY KEY,
rental_payment_id INT NOT NULL,
amount DECIMAL(10, 2) NOT NULL,
payment_type VARCHAR(20) NOT NULL
CHECK (payment_type IN ('ADVANCE', 'REGULAR', 'LATE_PAYMENT')),
payment_method VARCHAR(50) NOT NULL,
payment_date DATETIME DEFAULT GETDATE(),
notes TEXT,
created_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (rental_payment_id) REFERENCES rental_payments(id) 
);

--Tabla de mantenimiento
CREATE TABLE maintenance_types (
id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(100) NOT NULL,
description TEXT,
created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE maintenance_records (
id INT IDENTITY(1,1) PRIMARY KEY,
product_id INT NOT NULL,
maintenance_type_id INT NOT NULL,
store_id INT NOT NULL,
start_date DATETIME NOT NULL,
estimated_end_date DATETIME NOT NULL,
actual_end_date DATETIME,
status VARCHAR(20) NOT NULL
CHECK (status IN ('SCHEDULED', 'IN_PROGRESS', 'COMPLETED', 'CANCELLED')),
cost DECIMAL(10, 2),
technician_name VARCHAR(100),
description TEXT,
observations TEXT,
next_maintenance_date DATETIME,
created_at DATETIME DEFAULT GETDATE(),
updated_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (product_id) REFERENCES Products(id),
FOREIGN KEY (maintenance_type_id) REFERENCES maintenance_types(id),
FOREIGN KEY (store_id) REFERENCES Stores(id)
);

CREATE TABLE maintenance_tasks(
id INT IDENTITY(1,1) PRIMARY KEY,
maintenance_record_id INT NOT NULL,
task_name VARCHAR(200) NOT NULL,
description TEXT,
status VARCHAR(20) NOT NULL
CHECK (status IN ('PENDING', 'IN_PROGRESS', 'COMPLETED', 'CANCELLED')),
completed_at DATETIME,
created_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (maintenance_record_id) REFERENCES maintenance_records(id) 
);

CREATE TABLE maintenance_parts (
id INT IDENTITY(1,1) PRIMARY KEY,
maintenance_record_id INT NOT NULL,
part_name VARCHAR(100) NOT NULL,
quantity INT NOT NULL,
unit_cost DECIMAL(10, 2),
total_cost DECIMAL(10, 2),
supplier VARCHAR(100),
created_at DATETIME DEFAULT GETDATE(),
FOREIGN KEY (maintenance_record_id) REFERENCES maintenance_records(id)
);		

-----añadir de ultimoo
-- Create roles table
CREATE TABLE Roles (
id INT PRIMARY KEY IDENTITY(1,1),
name VARCHAR(50) NOT NULL UNIQUE,
description TEXT
);

-- Add role_id to Users table
ALTER TABLE Users
ADD role_id INT;

-- Add foreign key constraint
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Roles 
FOREIGN KEY (role_id) REFERENCES Roles(id);


-- Agregar rol admin primero
INSERT INTO Roles (name, description) 
VALUES ('Admin', 'Administrador del sistema');

--Create Table Category
CREATE TABLE Category(
Id INT PRIMARY KEY IDENTITY(1,1),
name VARCHAR(50)NOT NULL,
);

--Agregar registro categorias
INSERT INTO Category (name)
VALUES ('Maquina');

INSERT INTO Category(name)
VALUES('Equipos de construccion');


