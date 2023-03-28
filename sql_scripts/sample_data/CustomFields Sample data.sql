/*
*****************************************************************************
*
*	Developer script to inject some sample data
*	2023-03-28
*
*****************************************************************************
*/



SET IDENTITY_INSERT dbo.BlankForms ON
INSERT INTO dbo.BlankForms ([Id],[FormDescription], [Active])
VALUES
(1, 'Customer Form', 1),
(2, 'Customer Form', 1)
SET IDENTITY_INSERT dbo.BlankForms OFF

INSERT INTO dbo.FormInputFieldDefinitions ([BlankFormId],[Order],[StringData],[Name],[FieldType],[Placeholder],[IntegerData],[MaxLength],[MinLength])
VALUES
(1,1,'','',0,'Name',0,'10','3'),
(1,2,'','Address 1',0,'placeholder text',0,'10','3'),
(1,3,'','Address 2',0,'',0,'10','3'),
(1,4,'','Amount',1,'',0,'10','3'),
(2,1,'','',0,'Company Name',0,'10','3'),
(2,2,'','Address 1',0,'placeholder text',0,'1','3'),
(2,3,'','Address 2',0,'',0,'10','3'),
(2,4,'','Amount Employees',1,'',0,'10','3')

INSERT INTO dbo.Dispatches ([Email],[Status],[Id],[BlankFormId])
VALUES
('email1@test.com',2,'0fc0c2f2-7c2f-4a15-951a-5366589745cc',1),
('email1@test.com',2,'e487e2fb-9bab-4311-a727-659b30110359',2),
('email2@test.com',2,'4495c5da-bb32-4916-967b-d35573d4ecbd',1)



SELECT * FROM dbo.FormInputFieldAnswers

SELECT * FROM dbo.FormInputFieldDefinitions

SELECT * FROM Dispatches


/***	CLEAR Answers	***

update dbo.Dispatches
set [Status] = 2
where [Status] = 5
Truncate table dbo.FormInputFieldAnswers

***/