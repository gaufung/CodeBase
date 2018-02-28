package main

import (
	"fmt"
	"bufio"
	"os"
	"strings"
)
var nrchars, nrwords, nrlines = 0, 0, 0
func main(){
	inputReader := bufio.NewReader(os.Stdin)
	fmt.Println("Please input anything. 'S' for stop")


	for{
		input, err := inputReader.ReadString('\n')
		if err!=nil{
			fmt.Println("An error occurred: %s\n", err)
		}
		if input == "S\n"{
			fmt.Println("Here are the counts:")
			fmt.Printf("Number of the characters: %d\n", nrchars)
			fmt.Printf("Number of the words: %d\n", nrwords)
			fmt.Printf("Number of lines； %d\n", nrlines)
			os.Exit(0)
		}
		Counters(input)

	}
}

func Counters(input string){
	nrchars += len(input) - 2
	nrwords += len(strings.Fields(input))
	nrlines ++
}

