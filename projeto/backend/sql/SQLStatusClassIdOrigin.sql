USE walter_teste;

ALTER TABLE Student_Class 
ADD Status char(1);

ALTER TABLE Student_Class
ADD ClassId_Origin int;

ALTER TABLE Student_Class
ADD CONSTRAINT FK_Student_Class_Class_Origin
FOREIGN KEY (ClassId_Origin) REFERENCES Class(Id);