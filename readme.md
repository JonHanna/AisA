# A is A

Implementations of IEqualityComparer and IEqualityComparer<T> which ignore all overridden definitions of equality and compare based on identity alone.  
This deliberate usurpation of defined concepts of equality is normally counter-productive. It is however useful in the following cases:

1. A hash-based structure such as a Dictionary<TKey, TValue> is used to associate objects with another which may be equivalent to another using the same dictionary.
2. A hash-based structure such as a Dictionary<TKey, TValue> is used to associate objects with another which may mutate in such a way as to change the hash code based on its defined concept of equality.
3. As a (risky) optimisation, when it is known that no other equivalent objects exist, and therefore this object is the only one that would return true for an equality check. E.g. this would be the case with strings that had all been interned with string.Intern().

# License

> Licensed under the EUPL, Version 1.1 only (the “Licence”).  
> You may not use, modify or distribute this work except in compliance with the Licence.  
> You may obtain a copy of the Licence at:  
> <http://joinup.ec.europa.eu/software/page/eupl/licence-eupl>  
> A copy is also distributed with this source code.  
> Unless required by applicable law or agreed to in writing, software distributed under the  
> Licence is distributed on an “AS IS” basis, without warranties or conditions of any kind.