USE [ChallengeDb]
GO

-- Return a list of employees' names, and their manager's names (except the highest level employee who will 
-- have no manager - his or her manager should show "NULL" or empty).
SELECT emp.EmployeeName, emp2.EmployeeName AS ManagerName
FROM Employee emp
LEFT OUTER JOIN Employee AS emp2 ON emp.ManagerId = emp2.Id

-- Return a list of projects, and how many people are assigned to them
SELECT ProjectName, COUNT(pa.Id) AS NumAssignedEmployees
FROM Project
LEFT OUTER JOIN ProjectAssignment pa ON Project.Id = pa.ProjectId
GROUP BY ProjectName

-- Return the most senior person on the org chart assigned to a given project.
DECLARE @ProjectID INT
SELECT @ProjectID = 1

;WITH EmployeeList AS
(
	SELECT mgr.Id, mgr.EmployeeName, mgr.ManagerId, 1 AS OrgChart 
	FROM Employee AS mgr
	WHERE mgr.ManagerId IS NULL

	UNION ALL

	SELECT emp.Id, emp.EmployeeName, emp.ManagerId, elist.OrgChart + 1
	FROM Employee AS emp
	INNER JOIN EmployeeList as elist
	ON emp.ManagerId = elist.Id
	WHERE emp.ManagerId IS NOT NULL
)
SELECT TOP(1) EmployeeName 
FROM EmployeeList emps
INNER JOIN ProjectAssignment pa
ON pa.EmployeeId = emps.Id
WHERE pa.ProjectId = @ProjectID
ORDER BY OrgChart ASC