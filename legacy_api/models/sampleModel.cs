using System;

namespace LegacyAPI.Models
{
    /// <summary>
    /// Represents an order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        public DateTime OrderDate { get; set; }
    }

    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity.
        /// </summary>
        public int StockQuantity { get; set; }
    }

    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the hire date.
        /// </summary>
        public DateTime HireDate { get; set; }
    }

    /// <summary>
    /// Represents an order assignment.
    /// </summary>
    public class OrderAssignment
    {
        /// <summary>
        /// Gets or sets the assignment ID.
        /// </summary>
        public int AssignmentID { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the assignment date.
        /// </summary>
        public DateTime AssignmentDate { get; set; }
    }
}
