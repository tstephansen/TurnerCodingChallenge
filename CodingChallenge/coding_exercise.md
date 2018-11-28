
To submit your solution, preferably post your work product on a public repository like Github or Bitbucket. Alternatively, post an archive or zip of your solution on the web (public dropbox/box URL, personal web-site, etc), and provide us with the location.|


# Part 1: C# Coding Exercise
|                         |                                                                                                                                                                                                                                      |
|-------------------------|---------------------------------------|
| Platform                | Visual Studio 2013 or greater, C#     |
| Expected duration       | 45 mins - 1 hour                      |
| Deliverable             | A Visual Studio solution              |

## Problem Spec
---

For this exercise, you will use the REST API defined at [swapi.co](http://swapi.co/)

Implement a console application which takes the following command line arguments, in order:

1. A film title, enclosed in double-quotes
2. A property name on the [film entity](http://swapi.co/documentation#films) which represents a collection of other entities. For example, a film has a property named "characters" which is a JSON array with references to the set of [people](http://swapi.co/documentation#people) that appear in the film. The value for this second command line argument will be one of the following: "characters", "planets", "starships".
3. A property name, which will exist on the entity identified in number 2 above, and that propety will be a string property (not an array).

You should retrieve the film from the [films](http://swapi.co/documentation#films) resource whose title matches the first argument. For that film, retrieve all of the child element resources in the array property named by the second argument (characters, planets, starships). For each of these child entities write the value of the property named by the third argument to the console. Retrieve and write values with performance in mind (hint: parallelize requests for child entities if you can). Values should be written to the console as soon as they have been retrieved (ie. do not wait until all values are available before writing to the console), and duplicates should not be written to the console. The order in which values are written to the console does not matter.

For example, the command line invocation and output below yields a correct result:

```
C:\> MyApp.exe "Return of the Jedi" starships name
Millennium Falcon
Y-wing
X-wing
Executor
Imperial shuttle
EF76 Nebulon-B escort frigate
Calamari Cruiser
A-wing
B-wing
Star Destroyer
Rebel transport
CR90 corvette
```

Another example, which removes duplicates (There are two 'temperate' planets in the film "The Empire Strikes Back"):
```
C:\> MyApp.exe "The Empire Strikes Back" planets climate
frozen
murky
temperate
```

## Priorities and Constraints

There are few constraints: this is an open-ended exercise; you can use nuget packages, Google, and any version of the compiler or framework. Feel free to demonstrate your knowledge of the language, libraries, constructs, patterns, or tools that  might simplify your code, improve performance, and provide for extensibility or robustness. Demonstrate your experience by providing professional quality work and leveraging of skills or tools that are well suited to the problem

Make your priorities the following:

* Clean, comprehensible code
* Performance (and write values to the console as soon as they are available)

If you have any questions about this problem, feel free to ask by email.

# Part 2: Relational Modeling & Querying (SQL)
|                         |                                                                                                                                                                                                                                      |
|-------------------------|---------------------------------------------------------------------------|
| Platform                | Any popular relational database (T-SQL, PL/SQL, SqlLite, Postgres, etc.)  |
| Expected duration       | 20-30 minutes                                                             |
| Deliverable             | DDL (or a schema diagram); SQL scripts for queries                        |

## Problem Spec
### Model
Model the following problem using a relational schema to track a company's employees and projects using DDL or a schema diagram:
An employee has a name, a social security number, and a manager (except the highest employee in the org chart, who will have no manager).
Projects have a name.
Each project will have zero or many employees assigned to it. An employee can be assigned to many projects.

### Queries
Write queries against your schema to retrieve the following:
* Return a list of employees' names, and their manager's names (except the highest level employee who will have no manager - his or her manager should show "NULL" or empty).
* Return a list of projects, and how many people are assigned to them
* Return the most senior person on the org chart assigned to a given project
