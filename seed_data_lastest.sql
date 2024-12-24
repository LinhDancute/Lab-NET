create database LapDBBook
use LapDBBook

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX) NULL
);

CREATE TABLE Roles (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Users (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    Phone NVARCHAR(MAX) NOT NULL,
    Address NVARCHAR(MAX) NULL,
    RoleId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id) ON DELETE CASCADE
);

CREATE TABLE Carts (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TotalPrice FLOAT NOT NULL,
    UserId INT NOT NULL UNIQUE,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

CREATE TABLE Orders (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TotalAmount FLOAT NOT NULL,
    OrderDate DATETIME2 NOT NULL,
    ShippingAddress NVARCHAR(MAX) NOT NULL,
    Phone NVARCHAR(MAX) NOT NULL,
    PaymentMethod NVARCHAR(MAX) NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

CREATE TABLE Catalogues (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Title NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    IsActive BIT NOT NULL
);

CREATE TABLE Books (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Title NVARCHAR(MAX) NOT NULL,
    Author NVARCHAR(MAX) NOT NULL,
    Quantity INT NOT NULL,
    Publisher NVARCHAR(MAX) NOT NULL,
    Price FLOAT NOT NULL,
    DiscountPrice FLOAT NOT NULL,
    CreateOn DATETIME2 NOT NULL,
    Description NVARCHAR(MAX) NULL,
    IsActive BIT NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE CASCADE
);

CREATE TABLE BookCatalogues (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    BookId INT NOT NULL,
    CatalogueId INT NOT NULL,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE,
    FOREIGN KEY (CatalogueId) REFERENCES Catalogues(Id) ON DELETE CASCADE
);

CREATE TABLE CartDetails (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    CartId INT NOT NULL,
    BookId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (CartId) REFERENCES Carts(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);

CREATE TABLE OrderDetails (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    OrderId INT NOT NULL,
    BookId INT NOT NULL,
    Quantity INT NOT NULL,
    Price FLOAT NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    FOREIGN KEY (BookId) REFERENCES Books(Id) ON DELETE CASCADE
);

-- Create indexes for navigation properties
CREATE INDEX IX_Users_RoleId ON Users(RoleId);
CREATE INDEX IX_Carts_UserId ON Carts(UserId);
CREATE INDEX IX_Orders_UserId ON Orders(UserId);
CREATE INDEX IX_Books_CategoryId ON Books(CategoryId);
CREATE INDEX IX_BookCatalogues_BookId ON BookCatalogues(BookId);
CREATE INDEX IX_BookCatalogues_CatalogueId ON BookCatalogues(CatalogueId);
CREATE INDEX IX_CartDetails_CartId ON CartDetails(CartId);
CREATE INDEX IX_CartDetails_BookId ON CartDetails(BookId);
CREATE INDEX IX_OrderDetails_OrderId ON OrderDetails(OrderId);
CREATE INDEX IX_OrderDetails_BookId ON OrderDetails(BookId);

-- Seed Roles
INSERT INTO Roles (Name) VALUES ('Admin');
INSERT INTO Roles (Name) VALUES ('User');

-- Seed Users
INSERT INTO Users (Name, Email, Password, Phone, Address, RoleId) VALUES 
('Admin User', 'admin@example.com', '123', '1234567890', 'Admin Address', 1), -- RoleId = 1 (Admin)
('Regular User', 'user@example.com', '123', '0987654321', 'User Address', 2);  -- RoleId = 2 (User)

-- Seed Categories
INSERT INTO Categories (Name, Description) VALUES
('Science Fiction', 'Books related to futuristic science concepts and space exploration'),
('Fantasy', 'Books featuring magical or supernatural elements'),
('History', 'Books about historical events and people');

-- Seed Books
INSERT INTO Books (Title, Author, Quantity, Publisher, Price, DiscountPrice, CreateOn, Description, IsActive, CategoryId) VALUES 
('Dune', 'Frank Herbert', 10, 'Chilton Books', 25.99, 19.99, GETDATE(), 'A science fiction novel about the desert planet Arrakis.', 1, 1), -- CategoryId = 1 (Science Fiction)
('1984', 'George Orwell', 15, 'Secker & Warburg', 20.99, 15.99, GETDATE(), 'A dystopian social science fiction novel.', 1, 1), -- CategoryId = 1 (Science Fiction)
('The Hobbit', 'J.R.R. Tolkien', 20, 'George Allen & Unwin', 22.50, 17.99, GETDATE(), 'A fantasy novel and children''s book.', 1, 2), -- CategoryId = 2 (Fantasy)
('Harry Potter and the Sorcerer''s Stone', 'J.K. Rowling', 30, 'Bloomsbury', 24.99, 19.99, GETDATE(), 'A fantasy novel about a young wizard.', 1, 2), -- CategoryId = 2 (Fantasy)
('The Lord of the Rings', 'J.R.R. Tolkien', 25, 'George Allen & Unwin', 35.00, 29.99, GETDATE(), 'An epic fantasy novel.', 1, 2), -- CategoryId = 2 (Fantasy)
('Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 12, 'Harvill Secker', 29.99, 24.99, GETDATE(), 'A book about the history and evolution of humankind.', 1, 3), -- CategoryId = 3 (History)
('The Art of War', 'Sun Tzu', 40, 'Shambhala', 15.00, 12.50, GETDATE(), 'A treatise on strategy and tactics.', 1, 3), -- CategoryId = 3 (History)
('The Great Gatsby', 'F. Scott Fitzgerald', 18, 'Charles Scribner''s Sons', 18.99, 14.99, GETDATE(), 'A novel about the American dream.', 1, 3), -- CategoryId = 3 (History)
('Foundation', 'Isaac Asimov', 14, 'Gnome Press', 26.99, 21.99, GETDATE(), 'A science fiction series about the collapse of a galactic empire.', 1, 1), -- CategoryId = 1 (Science Fiction)
('Brave New World', 'Aldous Huxley', 22, 'Chatto & Windus', 21.50, 17.50, GETDATE(), 'A dystopian social science fiction novel.', 1, 1); -- CategoryId = 1 (Science Fiction)
