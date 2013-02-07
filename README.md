# Phrase maker

Phrase maker is a library used to generate code phrases. It can be used for instance to add a human readable code word to a text document to easily match it to a software entity (for instance an order, a contract, etc.).

## Installation

TODO: Nuget

## Usage
	
	var factory = new PhraseMakerFactory();
	var phraseMaker = factory.Create("no-nb");
	
	//Generates for instance "red car"
	var phrase = phraseMaker.GeneratePhrase();

## Dictionaries

TODO