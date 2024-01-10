#include <iostream>
#include <vector>
#include <functional>
#include <cctype>

using namespace std;

class StartsWithAny {
private:
    string startString;

public:   
    StartsWithAny(const string& startchar) : startString(startchar) {}
    function<bool(string)> getPredicate() {
        return [&](string stringItem) { return stringItem.starts_with(startString) == 0; };
    }
};

class Filter{
public:
    vector<string> applyFilter(vector<string>& arr, function<bool(const string&)> criteria){
        vetcor<string>& filterResult;
        for (const auto &element: arr){
            if(criteria(element)){
                filterResult.push_back(element);
            }
        }
        return filterResult;
    }
};

class DisplayResult{
public:
    void display(vector<string> arr) {
        Filter filterobj;
        std::function<bool(string)> startswithA = StartsWithAny("A").getPredicate();
        vector<string> result = filterobj.applyFilter(arr, startswithA);
        for (const auto &element: result){
            cout << element << endl;
        }
    }
};

int main()
{
    vector<string> arr = {"abc", "A", "Xyz"};
    
    DisplayResult displayobj;
    displayobj.display(arr);
    
    return 0;
}
