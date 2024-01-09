#include <iostream>
#include <vector>
#include <functional>
#include <cctype>

using namespace std;

bool starts_with_lowercase(string element){
    if(islower(element[0])){
        return true;
    }
    return false;
}

// Implementing closure
std::function<bool(std::string)> checkStringStartWithAny(std::string startString){
    std::function<bool(std::string)> predicateFuncObj = [&](std::string stringItem) { return stringItem.starts_with(startString); }
    return predicateFuncObj;
}

vector<string> filter(vector<string>& arr, function<bool(const string&)> criteria){
    vector<string> result;
    for(const auto &element: arr){
        if(criteria(element)){
            result.push_back(element);
        }
    }
    return result;
}

void display_result(vector<string> arr){
    vector<string> result = filter(arr, starts_with_lowercase);
    for (const auto &element: result){
        cout << element << endl;
    }
}

int main()
{
    
    vector<string> arr = {"abc", "qwerty","Xyz"};
    // Written for closure
    std::function<bool(std::string)> startswithA = checkStringStartWithAny("A");
    std::vector<std::string> filterStartWithA = filter(arr, startswithA);
    
    display_result(arr);
    return 0;
}

