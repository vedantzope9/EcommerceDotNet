	CREATE TABLE Products(
		ProductId INT AUTO_INCREMENT  PRIMARY KEY ,
        ProductName VARCHAR(250) NOT NULL,
        Price DECIMAL(10,2) NOT NULL,
        IsActive TINYINT(1) DEFAULT 1
    );
    
    
    CREATE TABLE Orders(
		OrderId INT AUTO_INCREMENT PRIMARY KEY,
        CustomerName VARCHAR(250) NOT NULL,
        TotalAmount DECIMAL(15,2) NOT NULL,
        OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
        Status ENUM('Placed', 'Cancelled') NOT NULL DEFAULT 'Placed'
    );
    
    CREATE TABLE OrderItems(
		OrderItemId INT AUTO_INCREMENT PRIMARY KEY,
		OrderId INT ,
		ProductId INT ,
		Quantity INT NOT NULL,
        FOREIGN KEY(OrderId) REFERENCES Orders(OrderId),
        FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
    )