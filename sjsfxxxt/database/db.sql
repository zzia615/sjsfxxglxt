create table denglu
(
zh nvarchar(20) not null primary key, --账号
xm nvarchar(20) not null,             --姓名
mm nvarchar(50) not null              --密码
)
go

insert into denglu(zh,xm,mm) values('my','my','123456')
go

create table shoujishoufei
(
id int identity(1,1) primary key,        --主键
mc nvarchar(50) not null,                --名称
xh nvarchar(100) not null,               --型号
jhrq date not null,                      --进货日期
sl int default 0 not null,               --数量
dj float default 0 not null              --单价
)
go