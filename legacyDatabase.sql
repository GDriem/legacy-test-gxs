CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    TotalPrice DECIMAL(10, 2),
    OrderDate DATETIME
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT,
    LinePrice DECIMAL(10, 2) -- Calculado como UnitPrice * Quantity
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


-- Cree la tabla de detalle de ordenes para mejorar la normalización
-- asi tiene mas legibilidad y mantenibilidad
-- Borre los campos repetidos de la tabla Orders por que ya estan en la tabla de Customers