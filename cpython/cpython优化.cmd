echo "https://www.cnblogs.com/xybaby/p/6510941.html“

python setup.py build_ext --inplace

python -c "import Server_CreateDB;Server_CreateDB.main()