CREATE TABLE Address(
address_id INT PRIMARY Key IDENTITY(1,1) ,
street varchar(100) ,
city varchar(50),
state varchar(50),
zip_code varchar(10)
);


create table Patient (
patient_id INT primary key IDENTITY(1,1),
first_name varchar(50),
last_name varchar(50),
phone_number varchar(20),
email varchar(100),
dob Date , 
address_id int UNIQUE ,
Foreign key (address_id) references Address(address_id)
);


create table Surgery (
surgery_id INT primary key IDENTITY(1,1),
name varchar(50),

phone_number varchar(20),

address_id int UNIQUE ,
Foreign key (address_id) references Address(address_id)
);



create table Dentist (
dentist_id  INT primary key IDENTITY(1,1),
first_name VARCHAR(50),
    last_name VARCHAR(50),
    phone_number VARCHAR(20),
    email VARCHAR(100),
    specialization VARCHAR(100)
);



create table Appointement (
appointment_id INT primary key IDENTITY(1,1),
appointment_date DATE,
    appointment_time TIME,
    patient_id INT,
    dentist_id INT,
    surgery_id INT,
	foreign key (patient_id) references Patient(patient_id),
	foreign key (dentist_id) references Dentist(dentist_id),
	foreign key (surgery_id) references Surgery(surgery_id)
);


SELECT * FROM Dentist ORDER BY last_name ASC;


SELECT a.*, p.first_name, p.last_name 
FROM Appointement a
JOIN Patient p ON a.patient_id = p.patient_id
WHERE a.dentist_id = 1;




SELECT * FROM Appointement WHERE surgery_id = 1;


SELECT * FROM Appointement 
WHERE patient_id = 6 AND appointment_date = '2025-10-14';

