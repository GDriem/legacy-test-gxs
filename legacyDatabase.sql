CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerName NVARCHAR(100),
    CustomerEmail NVARCHAR(100),
    ProductID INT,
    ProductName NVARCHAR(100),
    Quantity INT,
    TotalPrice DECIMAL(10, 2),
    OrderDate DATETIME
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(15)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    UnitPrice DECIMAL(10, 2),
    StockQuantity INT
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Role NVARCHAR(50),
    HireDate DATETIME
);

CREATE TABLE OrderAssignments (
    AssignmentID INT PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    AssignmentDate DATETIME
);
