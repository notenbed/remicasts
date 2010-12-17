Factory.sequence(:number){|n| n }

Factory.define :dog do |o|
  o.name  { "Rover #{ :number.next }" }
  o.breed 'Golden Retriever'
end
