USE [ChallengeDb]
GO

/*************************************** INSERT DATA ***************************************/
-- INSERT EMPLOYEES
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Senior Manager One', 12345101) --1
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Worker Two', 12345102) --2
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Middle Manager Two', 12345103) --3
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Senior Manager Two', 12345104) --4
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Boss Man', 12345105) --5
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Middle Manager One', 12345106) --6
INSERT INTO Employee(EmployeeName, EmployeeSocial) VALUES ('Worker One', 12345107) --7

-- SET MANAGER IDS
UPDATE Employee SET ManagerId = 5 WHERE Id = 1 OR Id = 4
UPDATE Employee SET ManagerId = 1 WHERE Id = 6
UPDATE Employee SET ManagerId = 4 WHERE Id = 3
UPDATE Employee SET ManagerId = 3 WHERE Id = 2
UPDATE Employee SET ManagerId = 6 WHERE Id = 7

-- CREATE FIVE PROJECTS
INSERT INTO Project(ProjectName) VALUES ('Project 1')
INSERT INTO Project(ProjectName) VALUES ('Project 2')
INSERT INTO Project(ProjectName) VALUES ('Project 3')
INSERT INTO Project(ProjectName) VALUES ('Project 4')
INSERT INTO Project(ProjectName) VALUES ('Project 5')

-- ASSIGN THE FOLLOWING PEOPLE TO THOSE PROJECTS
--Project 1 -> Middle Manager 1, Worker Two
--Project 2 -> Senior Manager 2, Middle Manager 1, Worker 1
--Project 3 -> Senior Manager 2, Senior Manager 1, Worker 2
--Project 4 -> Boss Man, Senior Manager 1
--Project 5 -> No employees assigned

-- Project 1
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (1, 6)
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (1, 2)
-- Project 2
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (2, 4)
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (2, 6)
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (2, 7)
-- Project 3
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (3, 4)
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (3, 1)
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (3, 2)
-- Project 4
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (4, 5)
INSERT INTO ProjectAssignment(ProjectId, EmployeeId) VALUES (4, 1)