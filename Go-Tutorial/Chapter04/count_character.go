package main

import (
	"fmt"
	"unicode/utf8"
)

func main() {
	str1 := "iecase"
	fmt.Printf("the number of bytes in string str1 is: %d\n", len(str1))
	fmt.Printf("the number of bytes in string str1 is: %d\n", utf8.RuneCountInString(str1))
	str2 := "高峰ん"
	fmt.Printf("the number of bytes in string str2 is: %d\n", len(str2))
	fmt.Printf("the number of bytes in string str2 is: %d\n", utf8.RuneCountInString(str2))
}
