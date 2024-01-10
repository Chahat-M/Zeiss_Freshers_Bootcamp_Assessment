#include <iostream>
#include <vector>
#include <functional>
#include <cctype>
#include <algorithm>

using namespace std;

class StartsWithStrategy {
private:
    string startString;

public: 
    void setStartsWith(const string& startchar){
        startString = startchar;
    }

    bool invoke(string item) {
        return item.starts_with(startString) == 0;
    }
};

class StringListFilterController{
private:
        StartsWithStrategy criteria;
public:
    vector<string> applyFilter(vector<string>& arr){
        criteria.setStartsWith("A");
        vector<string> filterResult;
        for (const auto &element: arr){
            if(criteria.invoke(element)){
                filterResult.push_back(element);
            }
        }
        return filterResult;
    }
};

class ConsoleDisplayController{
private: 
    vector<string> content;
public:
    void setContent(vector<string> msg){
        content.assign(msg.begin(), msg.end());
    }

    void display() {
        for (const auto &element: content){
            cout << element << endl;
        }
    }
};

int main()
{
    vector<string> arr = {"abc", "A", "Xyz"};
    
    ConsoleDisplayController displayobj;
    displayobj.setContent(arr);
    displayobj.display();
    
    return 0;
}
