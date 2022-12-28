# Rider environment problem

## Prerequisites 

1. Install `openssl` with `homebrew` on a mac
2. Open the project in **Rider** and change the _Environment variables_ in the run configuration to point to the openssl path
    e.g. `DYLD_LIBRARY_PATH=/usr/local/opt/openssl/lib`

## Reproduce error

1. Run project in Rider 2022.2 --> working
2. Run project in Rider 2022.3 --> not working

