use sjsfglxt
go

create table yhxx
(
yhzh nvarchar(20) not null primary key, --账号
yhxm nvarchar(20) not null,             --姓名
yhmm nvarchar(50) not null              --密码
)
go

insert into yhxx(yhzh,yhxm,yhmm) values('admin','admin','admin')
go
insert into yhxx(yhzh,yhxm,yhmm) values('my','my','123456')
go

create table sjsfgl
(
id int identity(1,1) primary key,        --主键
mc nvarchar(50) not null,                --名称
xh nvarchar(100) not null,               --型号
sfrq date not null,                      --收费日期
sl int default 0 not null,               --数量
dj float default 0 not null,             --单价
sfy nvarchar(50) not null                --收费员
)
go