package main

import (
	"fmt"
	"io"
	"os"
)

func main(){
	CopyFile("./Chapter12/output_copy.dat","output.dat")
	fmt.Println("Done")
}

func CopyFile(dstName, scrName string) (written int64, err error){
	src, err := os.Open(scrName)
	if err != nil{
		return
	}
	defer src.Close()

	dst, err := os.OpenFile(dstName, os.O_WRONLY | os.O_CREATE, 0664)
	if err!=nil{
		return
	}
	defer dst.Close()

	return io.Copy(dst, src)
}