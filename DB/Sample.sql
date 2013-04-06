
USE [Enrollment_DSS]
GO

INSERT INTO [dbo].[NhanViens]
           ([ID]
           ,[HoTen])
     VALUES
           (0
           ,N'Nguyễn Văn Được')
GO

INSERT INTO [dbo].[NhanViens]
           ([ID]
           ,[HoTen])
     VALUES
           (1
           ,N'Nguyễn Thị Úc My')
GO

INSERT INTO [dbo].[NhanViens]
           ([ID]
           ,[HoTen])
     VALUES
           (2
           ,N'Nguyễn Thị Thanh Phượng')
GO

INSERT INTO [dbo].[NhanViens]
           ([ID]
           ,[HoTen])
     VALUES
           (3
           ,N'Nguyễn Thị Thủy Tiên')
GO





USE [Enrollment_DSS]
GO

INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description])
     VALUES
           (N'Quản lý Sinh Viên'
           ,'Student manager')
GO

INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description])
     VALUES
           (N'Quản lý Phòng'
           ,'Room manager')
GO

INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description])
     VALUES
           (N'Quản lý Thiết bị'
           ,'Equipment manager')
GO

INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description])
     VALUES
           (N'Quản lý Nhân viên'
           ,'Staff manager')
GO

INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description])
     VALUES
           (N'Quản lý tối cao'
           ,'Administrator')
GO

INSERT INTO [dbo].[Accounts]
           ([UserName]
           ,[Password]
           ,[RoleID])
     VALUES
           ('nguyenvanduoc'
           ,'fathertime'
           ,1)
GO

USE [Enrollment_DSS]
GO

INSERT INTO [dbo].[Accounts]
           ([UserName]
           ,[Password]
           ,[RoleID])
     VALUES
           ('nguyenthiucmy'
           ,'fathertime'
           ,1)
GO

INSERT INTO [dbo].[Accounts]
           ([UserName]
           ,[Password]
           ,[RoleID])
     VALUES
           ('nguyenthithanhtuyen'
           ,'fathertime'
           ,2)
GO


INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('0'
           ,N'Ngoại ngữ')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('1'
           ,N'Mỹ thuật công nghiệp')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('2'
           ,N'Kế toán tài chính')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('3'
           ,N'Xã hội nhân văn')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('4'
           ,N'Điện - điện tử')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('5'
           ,N'Công nghệ thông tin')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('6'
           ,N'Khoa học ứng dụng')
GO


INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('7'
           ,N'Quản trị kinh doanh')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('8'
           ,N'Kỹ thuật công trình')
GO

INSERT INTO [dbo].[Faculties]
           ([FacultyID]
           ,[FacultyName])
     VALUES
           ('9'
           ,N'Môi trường và bảo hộ lao động')
GO


INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('0'
           ,'A1'
           ,'A'
           ,'1'
           ,N'Khối nữ, dãy 1')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('1'
           ,'A2'
           ,'A'
           ,'2'
           ,N'Khối nữ, dãy 2')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('2'
           ,'A3'
           ,'A'
           ,'3'
           ,N'Khối nữ, dãy 3')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('3'
           ,'A4'
           ,'A'
           ,'4'
           ,N'Khối nữ, dãy 4')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('4'
           ,'A5'
           ,'A'
           ,'5'
           ,N'Khối nữ, dãy 5')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('5'
           ,'A6'
           ,'A'
           ,'6'
           ,N'Khối nữ, dãy 6')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('6'
           ,'A7'
           ,'A'
           ,'7'
           ,N'Khối nữ, dãy 7')
GO


INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('7'
           ,'B1'
           ,'B'
           ,'1'
           ,N'Khối Nam, dãy 1')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('8'
           ,'B2'
           ,'B'
           ,'2'
           ,N'Khối Nam, dãy 2')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('9'
           ,'B3'
           ,'B'
           ,'3'
           ,N'Khối Nam, dãy 3')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('10'
           ,'B4'
           ,'B'
           ,'4'
           ,N'Khối Nam, dãy 4')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('11'
           ,'B5'
           ,'B'
           ,'5'
           ,N'Khối Nam, dãy 5')
GO

INSERT INTO [dbo].[RowRooms]
           ([ID]
           ,[Name]
           ,[Block]
           ,[Floor]
           ,[Note])
     VALUES
           ('12'
           ,'B6'
           ,'B'
           ,'6'
           ,N'Khối Nam, dãy 6')
GO


INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('0'
           ,'0'
           ,'Phòng 0'
           ,'0'
           ,8
           ,1)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('1'
           ,'1'
           ,'Phòng 1'
           ,'0'
           ,8
           ,1)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('2'
           ,'2'
           ,'Phòng 2'
           ,'0'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('3'
           ,'3'
           ,'Phòng 3 RowID 2'
           ,'2'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('4'
           ,'4'
           ,'Phòng 4 RowID 3'
           ,'3'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('5'
           ,'5'
           ,'Phòng 5 RowID 4'
           ,'4'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('6'
           ,'6'
           ,'Phòng 6 RowID 5'
           ,'5'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('7'
           ,'7'
           ,'Phòng 7 RowID 6'
           ,'6'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('8'
           ,'8'
           ,'Phòng 8 RowID 7'
           ,'7'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('9'
           ,'9'
           ,'Phòng 9 RowID 8'
           ,'8'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('10'
           ,'10'
           ,'Phòng 10 RowID 9'
           ,'9'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('11'
           ,'11'
           ,'Phòng 11 RowID 10'
           ,'10'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('12'
           ,'12'
           ,'Phòng 12 RowID 11'
           ,'11'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('13'
           ,'13'
           ,'Phòng 13 RowID 12'
           ,'12'
           ,8
           ,0)
GO

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('14'
           ,'14'
           ,'Phòng 14 RowID 12'
           ,'12'
           ,8
           ,0)
GO

use Enrollment_DSS

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('17'
           ,'17'
           ,'Phòng 17'
           ,'1'
           ,8
           ,1)
GO

use Enrollment_DSS

INSERT INTO [dbo].[Rooms]
           ([RoomID]
           ,[Name]
           ,[Note]
           ,[RowID]
           ,[MaxStudent]
           ,[Status])
     VALUES
           ('15'
           ,'15'
           ,'Phòng 15'
           ,'1'
           ,8
           ,1)
GO