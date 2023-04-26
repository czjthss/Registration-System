CREATE DATABASE Assignment3_Design_And_Implementation;
USE Assignment3_Design_And_Implementation;

--登录界面
--ID
--密码
--权限(运动员、教练员、参赛队管理员、主办方管理员)
--

--第一张表(登记界面后选择需要操作的运动会)[主办方管理员权限]

DROP TABLE 运动会信息表;

CREATE TABLE 运动会信息表(
    运动会ID  VARCHAR(50) PRIMARY KEY ,
    运动会名称 VARCHAR(50) NOT NULL ,
    主办单位 VARCHAR(50) NOT NULL ,
    承办单位 VARCHAR(50) NOT NULL ,
    地点 VARCHAR(50) NOT NULL ,
    比赛时间 DATE NOT NULL ,
    结束时间 DATE NOT NULL,
    生效标记 TINYINT NOT NULL DEFAULT 0
)

--第二张表(管理参赛队)[参赛队管理员权限]

DROP TABLE 参赛队信息表;

CREATE TABLE 参赛队信息表(
    参赛队ID VARCHAR(50) PRIMARY KEY ,
    运动会ID VARCHAR(50) NOT NULL  ,
    学校 VARCHAR(50) NOT NULL,
    参赛队全称 VARCHAR(50) NOT NULL ,
    最小号码 VARCHAR(50) NOT NULL ,
    最大号码 VARCHAR(50) NOT NULL ,
    生效标记 TINYINT NOT NULL DEFAULT 0,

    FOREIGN KEY (运动会ID) REFERENCES 运动会信息表(运动会ID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
)

--第三张表(管理运动会项目)[主办方管理员权限]

DROP TABLE 项目信息表;

CREATE TABLE 项目信息表(
    项目ID VARCHAR(50) PRIMARY KEY ,
    运动会ID VARCHAR(50) NOT NULL  ,
    项目名称 VARCHAR(50) NOT NULL ,
    项目类型 VARCHAR(50) NOT NULL ,
    团体项目标记 TINYINT NOT NULL,

    FOREIGN KEY (运动会ID) REFERENCES 运动会信息表(运动会ID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
)

--第四张表(管理运动员信息,与具体运动会无关)[运动员权限]

DROP TABLE 运动员注册表;

CREATE TABLE 运动员注册表(
    运动员ID VARCHAR(50) PRIMARY KEY ,
    运动员账号 VARCHAR(50) NOT NULL ,
    姓名 VARCHAR(50) NOT NULL ,
    性别 VARCHAR(50) NOT NULL ,
    学校 VARCHAR(50) NOT NULL,
    入学时间 DATE NOT NULL ,
    毕业时间 DATE NOT NULL ,
    教练员ID VARCHAR(50) NOT NULL ,
    生效标记 TINYINT NOT NULL DEFAULT 0,

    FOREIGN KEY (运动员账号) REFERENCES 运动员登录表(运动员账号)
    ON DELETE CASCADE
    ON UPDATE CASCADE,

    FOREIGN KEY (教练员ID) REFERENCES 教练员注册表(教练员ID)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)

--运动员信息表是运动员注册表的subclass

--第五张表(具体运动会的运动员参赛名单)[参赛队管理员权限]

DROP TABLE 运动员信息表;

CREATE TABLE 运动员信息表(
    运动员ID VARCHAR(50) NOT NULL ,
    参赛队ID VARCHAR(50) NOT NULL ,
    号码 VARCHAR(50) NOT NULL ,
    报名项目一 VARCHAR(50) NOT NULL ,
    报名项目二 VARCHAR(50),

    PRIMARY KEY (运动员ID,参赛队ID),

    FOREIGN KEY (参赛队ID) REFERENCES 参赛队信息表(参赛队ID)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)


--第六张表(管理教练员信息,与具体运动会无关)[教练员权限]

DROP TABLE 教练员注册表;

CREATE TABLE 教练员注册表(
    教练员ID VARCHAR(50) PRIMARY KEY ,
    教练员账号 VARCHAR(50) NOT NULL ,
    姓名 VARCHAR(50) NOT NULL ,
    学校 VARCHAR(50) NOT NULL ,
    职称 VARCHAR(50) NOT NULL ,
    生效标记 TINYINT NOT NULL DEFAULT 0,
)


--第七张表(具体运动会的教练员参加名单)[参赛队管理员权限]

DROP TABLE 教练员信息表;

CREATE TABLE 教练员信息表(
    教练员ID VARCHAR(50)NOT NULL ,
    参赛队ID VARCHAR(50) NOT NULL ,

    PRIMARY KEY (教练员ID,参赛队ID),

    FOREIGN KEY (参赛队ID) REFERENCES 参赛队信息表(参赛队ID)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)


--第八九十十一张表(登录界面用户名、密码)

--运动员登录表

DROP TABLE 运动员登录表;

CREATE TABLE 运动员登录表(
    运动员账号 VARCHAR(50) PRIMARY KEY ,
    密码 VARCHAR(50) NOT NULL ,
)


--教练员登录表

DROP TABLE 教练员登录表;

CREATE TABLE 教练员登录表(
    教练员账号 VARCHAR(50) PRIMARY KEY ,
    密码 VARCHAR(50) NOT NULL ,
)


--参赛队管理员登录表

DROP TABLE 参赛队管理员登录表;

CREATE TABLE 参赛队管理员登录表(
    参赛队管理员账号 VARCHAR(50) PRIMARY KEY ,
    密码 VARCHAR(50) NOT NULL ,
)

--主办方管理员登录表

DROP TABLE 主办方管理员登录表;

CREATE TABLE 主办方管理员登录表(
    主办方管理员账号 VARCHAR(50) PRIMARY KEY ,
    密码 VARCHAR(50) NOT NULL ,
)


--存储过程


--运动员编号检查
DROP PROCEDURE check_ID_yundongyuan;

CREATE PROCEDURE check_ID_yundongyuan
    @运动员ID VARCHAR(50),
    @参赛队ID VARCHAR(50),
    @学校 VARCHAR(50)
AS
    IF(@运动员ID IN (SELECT 运动员ID FROM 运动员信息表 WHERE 参赛队ID = @参赛队ID)) RETURN 0
    IF(@运动员ID NOT IN (SELECT 运动员ID FROM 运动员注册表 WHERE 生效标记=1 AND 学校 = @学校)) RETURN 0
    RETURN 1
GO

--教练员编号检查
DROP PROCEDURE check_ID_jiaolianyuan;

CREATE PROCEDURE check_ID_jiaolianyuan
    @教练员ID VARCHAR(50),
    @参赛队ID VARCHAR(50),
    @学校 VARCHAR(50)
AS
    IF(@教练员ID IN (SELECT 教练员ID FROM 教练员信息表 WHERE 参赛队ID = @参赛队ID)) RETURN 0
    IF(@教练员ID NOT IN (SELECT 教练员ID FROM 教练员注册表 WHERE 生效标记=1 AND 学校 = @学校)) RETURN 0
    RETURN 1
GO


--项目编号检查

DROP PROCEDURE check_xiangmu;

CREATE PROCEDURE check_xiangmu
    @项目ID1 VARCHAR(50),
    @项目ID2 VARCHAR(50),
    @运动会ID VARCHAR(50)
AS
    IF(@项目ID1 NOT IN (SELECT 项目ID FROM 项目信息表 WHERE 运动会ID = @运动会ID)) RETURN 0
    IF(@项目ID2 NOT IN (SELECT 项目ID FROM 项目信息表 WHERE 运动会ID = @运动会ID)) RETURN 0
    RETURN 1
GO

--号码重复错误

DROP PROCEDURE check_haoma;

CREATE PROCEDURE check_haoma
    @号码 VARCHAR(50),
    @参赛队ID VARCHAR(50)
AS
    IF(@号码 IN (SELECT 号码 FROM 运动员信息表 WHERE 参赛队ID = @参赛队ID)) RETURN 0
    RETURN 1
GO


--获得最大号码

DROP PROCEDURE get_max;

CREATE PROCEDURE get_max
    @参赛队ID VARCHAR(50)
AS
    RETURN (SELECT 最大号码 FROM 参赛队信息表 WHERE 参赛队ID = @参赛队ID)
GO

--获得最小号码



DROP PROCEDURE get_min;

CREATE PROCEDURE get_min
    @参赛队ID VARCHAR(50)
AS
    RETURN (SELECT 最大号码 FROM 参赛队信息表 WHERE 参赛队ID = @参赛队ID)
GO



--触发器，删参赛队



CREATE TRIGGER delete_cansaidui
    ON 参赛队信息表
    AFTER DELETE
    AS
    BEGIN
        DELETE 运动员信息表 WHERE 运动员信息表.参赛队ID IN (SELECT 参赛队ID FROM deleted)
        DELETE 教练员信息表 WHERE 教练员信息表.参赛队ID IN (SELECT 参赛队ID FROM deleted)
    END
GO

--触发器，删运动会

CREATE TRIGGER delete_yundonghui
    ON 运动会信息表
    AFTER UPDATE
    AS
    BEGIN
        UPDATE 参赛队信息表 SET 生效标记 = 0 WHERE 参赛队信息表.运动会ID IN (SELECT 运动会ID FROM deleted)
    END
GO