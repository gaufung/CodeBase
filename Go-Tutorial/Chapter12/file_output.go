package main

import (
	"fmt"
	"bufio"
	"os"
)

func main(){
	outputFile, outputFileError := os.OpenFile("output.dat", os.O_WRONLY|os.O_CREATE, 0666)
	if outputFileError != nil {
		fmt.Printf("An error occurred with file opening or creation\n")
		return
	}

	defer  outputFile.Close()

	outputWriter := bufio.NewWriter(outputFile)

	outputString := "Hello World\n"

	for i:=0;i<10;i++{
		outputWriter.WriteString(outputString)
	}

	outputWriter.Flush()
}
