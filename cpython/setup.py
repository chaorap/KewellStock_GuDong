from distutils.core import setup
from Cython.Build import cythonize

setup(
  name = 'Server_CreateDB',
  ext_modules = cythonize("Server_CreateDB.pyx"),
)