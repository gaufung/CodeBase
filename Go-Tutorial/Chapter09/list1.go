package main

import (
	"fmt"
	"container/list"
)
func main(){
	var list list.List;
	list.Init()
	list.PushFront(101)
	list.PushFront(102)
	list.PushFront(103)
	for e:=list.Front();e!=nil; e=e.Next(){
		fmt.Print(e.Value,"\n")
	}

}
