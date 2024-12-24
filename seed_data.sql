USE LapGKBook;

SET IDENTITY_INSERT [dbo].[Roles] ON;
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin');
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User');
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF;
GO

SET IDENTITY_INSERT [dbo].[Users] ON;
GO
INSERT [dbo].[Users] ([Id], [Email], [Password], [RoleId], [Name], [Address], [Phone]) VALUES (1, N'admin@gmail.com', N'123456', 1, 'ADMIN', 'Address', '0987654321');
GO
INSERT [dbo].[Users] ([Id], [Email], [Password], [RoleId], [Name], [Address], [Phone]) VALUES (2, N'user@gmail.com', N'123456', 2, 'USER', 'Address', '0987654321');
GO
SET IDENTITY_INSERT [dbo].[Users] OFF;
GO
