package main

import "fmt"
func duplicate(str []string) []string{
	filter := make([]string, len(str))
	index := 0
	for i:=1;i<len(str);i++{
		if str[i]==str[i-1]{
			filter[index] = str[i]
			index++
		}
	}
	return filter
}

func main(){
	strs := []string{"gao", "feng", "feng", "zhe"}
	duplicate:=duplicate(strs)
	fmt.Print(duplicate)
}
