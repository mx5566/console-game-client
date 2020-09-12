@echo off
rem 遍历开始
set path=.
cd %path%

for  %%i in (*.proto) do (.\protoc.exe %%i --csharp_out=.)


@pause
