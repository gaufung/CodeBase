package main

import (
	"fmt"
	"bufio"
	"io"
	"os"
)

func main(){
	inputfile, InputError := os.Open("Chapter12/fileinput.go")
	if InputError !=nil{
		fmt.Println("input error")
		return
	}
	defer  inputfile.Close()

	inputReader := bufio.NewReader(inputfile)

	for{
		inputString, readerError := inputReader.ReadString('\n')
		fmt.Printf("The input was: %s", inputString)
		if readerError==io.EOF{
			return
		}
	}
}
