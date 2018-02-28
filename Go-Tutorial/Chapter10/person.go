package main

import (
	"fmt"
	"strings"
)

type Person struct {
	firstname string
	lastname string
}

func upPerson(p *Person){
	p.firstname=strings.ToUpper(p.firstname)
	p.lastname=strings.ToUpper(p.lastname)
}

func main(){
	var pers1 Person
	pers1.firstname="Chris"
	pers1.lastname="Woodward"

	upPerson(&pers1)

	fmt.Printf("The name of the person is %s %s\n", pers1.firstname, pers1.lastname)

	pers2 := new(Person)
	pers2.firstname="Chris"
	pers2.lastname="Woodward"
	(*pers2).lastname="Woodward"
	upPerson(pers2)
	fmt.Printf("The name of the person is %s %s \n", pers2.firstname, pers2.lastname)

	pers3:=&Person{"Chris", "Woodward"}
	upPerson(pers3)
	fmt.Printf("The name of the person is %s %s\n", pers3.firstname, pers3.lastname)
}
