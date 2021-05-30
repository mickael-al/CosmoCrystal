@echo off
set GIT_PATH="C:\Program Files\Git\bin\git.exe"
%GIT_PATH% add -A
%GIT_PATH% commit -am "Auto-committed on %date% $now"
%GIT_PATH% pull
%GIT_PATH% push
