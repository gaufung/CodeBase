package main

import (
	"fmt"
	"encoding/json"
	//"log"
	//"os"
	"os"
	"log"
)

type Address struct {
	Type string
	City string
	Country string
}

type VCard struct {
	FirstName string
	LastName string
	Address []*Address
	Remark  string
}

func main(){
	pa := &Address{"private", "Aartselaar", "Belgium"}
	wa := &Address{"work", "Boom", "Belgium"}
	vc := VCard{"Jan", "Kersschot", []*Address{pa, wa}, "none"}

	js, _ := json.Marshal(vc)

	fmt.Printf("Json Format: %s\n", js)

	file, _:=os.OpenFile("vcard.json", os.O_CREATE | os.O_WRONLY, 0666)
	defer  file.Close()

	enc := json.NewEncoder(file)
	err := enc.Encode(js)

	if err != nil{
		log.Println("Error in encoding json" )
	}

	var v VCard
	json.Unmarshal([]byte(js), &v)
	fmt.Println(v)
}
