@echo off
set "fullstamp=%YYYY%-%MM%-%DD%_%HH%-%Min%-%Sec%"
set GIT_PATH="C:\Program Files\Git\bin\git.exe"
%GIT_PATH% add -A
%GIT_PATH% commit -am "Auto-committed on %fullstamp%"
%GIT_PATH% pull
%GIT_PATH% push
