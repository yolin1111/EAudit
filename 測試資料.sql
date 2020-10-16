SELECT *
FROM AuditHeaderAlls
SELECT *
FROM AuditLineAlls
--DELETE AuditHeaderAlls
--DELETE AuditLineAlls
--測試資料
--立案
INSERT INTO AuditHeaderAlls
    (AuditItem,ApplyOrg,ApplyDate,ApplyPeron,Source,SourceOthers,AuditReason,Others,Notes,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    ('01', 'BACC', '2020-09-10', 'M01', '1999', '', '隨便打', '隨便打', '隨便打', '2020-09-10', 'M01', '2020-09-10', 'M01')
--立案 + 稽查2
INSERT INTO AuditHeaderAlls
    (AuditItem,ApplyOrg,ApplyDate,ApplyPeron,Source,SourceOthers,AuditReason,Others,Notes,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    ('01', 'ABAA', '2020-09-10', 'M01', '1999', '', '隨便打', '隨便打', '隨便打', '2020-09-10', 'M01', '2020-09-10', 'M01')
INSERT INTO AuditLineAlls
    (HeaderId,CaseLineId,ApplyDate,AuditTime,Auditor,AuditAddress,Area,Auditee,CurrentViolation,CurrentPenalty,OtherOrg,Idn,Preclosed,Closed,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    (4, 'ABAA-01-0910-01', '2020-09-10', '2020-09-10', 'M02', '仁愛路一號', '123', '1231', 'test', 'adfadf', 'adfasdf', 'dsfad', 'true', 'false', '2020-09-10', 'M01', '2020-09-10', 'M01')
INSERT INTO AuditLineAlls
    (HeaderId,CaseLineId,ApplyDate,AuditTime,Auditor,AuditAddress,Area,Auditee,CurrentViolation,CurrentPenalty,OtherOrg,Idn,Preclosed,Closed,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    (4, 'ABAA-01-0910-02', '2020-09-10', '2020-09-10', 'M02', '仁愛路一號', '123', '1231', 'test', 'adfadf', 'adfasdf', 'dsfad', 'true', 'false', '2020-09-10', 'M01', '2020-09-10', 'M01')
--立案 + 稽查3
INSERT INTO AuditHeaderAlls
    (AuditItem,ApplyOrg,ApplyDate,ApplyPeron,Source,SourceOthers,AuditReason,Others,Notes,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    ('01', 'AGAA', '2020-09-10', 'M01', '1999', '', '隨便打', '隨便打', '隨便打', '2020-09-10', 'M01', '2020-09-10', 'M01')
INSERT INTO AuditLineAlls
    (HeaderId,CaseLineId,ApplyDate,AuditTime,Auditor,AuditAddress,Area,Auditee,CurrentViolation,CurrentPenalty,OtherOrg,Idn,Preclosed,Closed,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    (5, 'AGAA-01-0910-01', '2020-09-10', '2020-09-10', 'M02', '仁愛路100號', '123', '1231', 'test', 'adfadf', 'adfasdf', 'dsfad', 'true', 'false', '2020-09-10', 'M01', '2020-09-10', 'M01')
INSERT INTO AuditLineAlls
    (HeaderId,CaseLineId,ApplyDate,AuditTime,Auditor,AuditAddress,Area,Auditee,CurrentViolation,CurrentPenalty,OtherOrg,Idn,Preclosed,Closed,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    (5, 'AGAA-01-0910-02', '2020-09-10', '2020-09-10', 'M02', '仁愛路100號', '123', '1231', 'test', 'adfadf', 'adfasdf', 'dsfad', 'true', 'false', '2020-09-10', 'M01', '2020-09-10', 'M01')
INSERT INTO AuditLineAlls
    (HeaderId,CaseLineId,ApplyDate,AuditTime,Auditor,AuditAddress,Area,Auditee,CurrentViolation,CurrentPenalty,OtherOrg,Idn,Preclosed,Closed,CreationDate,CreatedBy,LastUpdateDate,LastUpdatedBy)
VALUES
    (5, 'AGAA-01-0910-03', '2020-09-10', '2020-09-10', 'M02', '仁愛路100號', '123', '1231', 'test', 'adfadf', 'adfasdf', 'dsfad', 'true', 'false', '2020-09-10', 'M01', '2020-09-10', 'M01')

/*
C
    POST https://172.18.40.4:5000/api/GetData
    {
        "auditItem": "01",
        "applyOrg": "ABAA",
        "applyDate": "2020-09-10T00:00:00",
        "applyPeron": "M01",
        "source": "1999",
        "sourceOthers": "",
        "auditReason": "隨便打",
        "others": "隨便打",
        "notes": "隨便打",
        "creationDate": "2020-09-10T00:00:00",
        "createdBy": "M01",
        "lastUpdateDate": "2020-09-10T00:00:00",
        "lastUpdatedBy": "M01"
    }

    {
    "auditItem": "01",
    "applyOrg": "ABAA",
    "applyDate": "2020-09-10T00:00:00",
    "applyPeron": "M01",
    "source": "1999",
    "sourceOthers": "",
    "auditReason": "隨便打",
    "others": "隨便打",
    "notes": "隨便打",
    "creationDate": "2020-09-10T00:00:00",
    "createdBy": "M01",
    "lastUpdateDate": "2020-09-10T00:00:00",
    "lastUpdatedBy": "M01",
    "auditLineAlls": [
            {
                "caseLineId": "ABAA-01-0910-01",
                "applyDate": "2020-09-10T00:00:00",
                "auditTime": "2020-09-10T00:00:00",
                "auditor": "M02",
                "auditAddress": "仁愛路一號",
                "area": "123",
                "auditee": "1231",
                "currentViolation": "test",
                "currentPenalty": "adfadf",
                "otherOrg": "adfasdf",
                "idn": "dsfad",
                "preclosed": "true",
                "closed": "false",
                "creationDate": "2020-09-10T00:00:00",
                "createdBy": "M01",
                "lastUpdateDate": "2020-09-10T00:00:00",
                "lastUpdatedBy": "M01"
            },
            {
                "caseLineId": "ABAA-01-0910-02",
                "applyDate": "2020-09-10T00:00:00",
                "auditTime": "2020-09-10T00:00:00",
                "auditor": "M02",
                "auditAddress": "仁愛路一號",
                "area": "123",
                "auditee": "1231",
                "currentViolation": "test",
                "currentPenalty": "adfadf",
                "otherOrg": "adfasdf",
                "idn": "dsfad",
                "preclosed": "true",
                "closed": "false",
                "creationDate": "2020-09-10T00:00:00",
                "createdBy": "M01",
                "lastUpdateDate": "2020-09-10T00:00:00",
                "lastUpdatedBy": "M01"
            }
        ]
    }
U
    PUT https://172.18.40.4:5000/api/GetData/8
    {
        "auditItem": "01",
        "applyOrg": "ABAA",
        "applyDate": "2020-09-10T00:00:00",
        "applyPeron": "M01",
        "source": "1999",
        "sourceOthers": "",
        "auditReason": "隨便打",
        "others": "隨便打",
        "notes": "隨便打",
        "creationDate": "2020-09-10T00:00:00",
        "createdBy": "M01",
        "lastUpdateDate": "2020-09-10T00:00:00",
        "lastUpdatedBy": "M01"
    }

    PUT https://172.18.40.4:5000/api/GetData/8
    {
        "headerId": 8,
        "auditItem": "01",
        "applyOrg": "ABAA",
        "applyDate": "2020-09-10T00:00:00",
        "applyPeron": "M01",
        "source": "1999",
        "sourceOthers": "",
        "auditReason": "我要修改第八筆",
        "others": "我要修改第八筆",
        "notes": "我要修改第八筆",
        "creationDate": "2020-09-10T00:00:00",
        "createdBy": "M01",
        "lastUpdateDate": "2020-09-10T00:00:00",
        "lastUpdatedBy": "M01",
        "auditLineAlls": [
            {
                "headerId": 8,
                "caseLineId": "ABAA-01-0910-01",
                "applyDate": "2020-09-10T00:00:00",
                "auditTime": "2020-09-10T00:00:00",
                "auditor": "M02",
                "auditAddress": "然後新增Line1",
                "area": "123",
                "auditee": "1231",
                "currentViolation": "test",
                "currentPenalty": "adfadf",
                "otherOrg": "adfasdf",
                "idn": "dsfad",
                "preclosed": "true",
                "closed": "false",
                "creationDate": "2020-09-10T00:00:00",
                "createdBy": "M01",
                "lastUpdateDate": "2020-09-10T00:00:00",
                "lastUpdatedBy": "M01"
            },
            {
                "headerId": 8,
                "caseLineId": "ABAA-01-0910-02",
                "applyDate": "2020-09-10T00:00:00",
                "auditTime": "2020-09-10T00:00:00",
                "auditor": "M02",
                "auditAddress": "然後新增Line12",
                "area": "123",
                "auditee": "1231",
                "currentViolation": "test",
                "currentPenalty": "adfadf",
                "otherOrg": "adfasdf",
                "idn": "dsfad",
                "preclosed": "true",
                "closed": "false",
                "creationDate": "2020-09-10T00:00:00",
                "createdBy": "M01",
                "lastUpdateDate": "2020-09-10T00:00:00",
                "lastUpdatedBy": "M01"
            }
        ]
    }

R
    GET http://172.18.40.4:5000/api/GetData
    GET http://172.18.40.4:5000/api/GetData/4
D
    DELETE https://172.18.40.4:5000/api/Blogs/1
*/

--http://localhost:5000/swagger 以檢視 Swagger UI。
--http://localhost:5000/swagger/v1/swagger.json 以檢視 Swagger 規格。
--https://localhost:5001/redoc/



--"applicationUrl": "https://172.18.40.4:5001;http://172.18.40.4:5000",
--"applicationUrl": "https://localhost:5001;http://localhost:5000",