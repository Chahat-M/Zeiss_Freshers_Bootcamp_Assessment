#include <iostream>
#include <vector>

using namespace std;

class Header;
class Paragraph;
class Footer;

class DocumentParts: public IConverter{
public:
  string name;
  int position;
  
  DocumentParts(const string& text, int pos) : name(text), position(pos) {}
  
  virtual void paint() = 0;
  virtual void save() = 0;
  virtual void convert(IConverter* Iconverterobj) = 0;
};

class Header: public DocumentParts{
public:
    string title;
    
    Header(const std::string& text, int pos, const std::string& t) : DocumentParts(text,pos), title(t) {}
    
    void paint() override{
        cout<<title<<endl;
    }
    
    void save() override{
        cout<<"Saving"<<endl;
    }
    
    void convert(IConverter* Iconverterobj) override{
        Iconverterobj->convert(this);
    }
};

class Paragraph: public DocumentParts{
    string content;
    
    Paragraph(const std::string& text, int pos, const std::string& t) : DocumentParts(text,pos), content(t) {}
    
    void paint() override{
        cout<<content<<endl;
    }
    
    void save() override{
        cout<<"Saving"<<endl;
    }
    
    void convert(IConverter* Iconverterobj) override{
        Iconverterobj->convert(this);
    }
};

class Footer: public DocumentParts{
    string footer_text;
    
    Footer(const std::string& text, int pos, const std::string& t) : DocumentParts(text,pos), footer_text(t) {}
    
    void paint() override{
        cout<<footer_text<<endl;
    }
    
    void save() override{
        cout<<"Saving"<<endl;
    }
    
    void convert(IConverter* Iconverterobj) override{
        Iconverterobj->convert(this);
    }
};

class IConverter{
public:
    virtual void convert(Header* headerobj) = 0;
    virtual void convert(Footer* footerobj) = 0;
    virtual void convert(Paragraph* paraobj) = 0;
};

class HTMLConverter: public IConverter{
public:
    void convert(Header* headerobj) override{
        cout<<"Converting Header"<<endl;
    };
    void convert(Footer* footerobj){
        cout<<"Converting footer"<<endl;
    };
    void convert(Paragraph* paraobj){
        cout<<"Converting paragraph"<<endl;
    };
};

class WordDocument: public Iconverter{
public:
  vector<DocumentParts*> parts;

    void open(){
        for(auto part: parts)
            part->paint();
    }
    
    void save(){
        for(auto part: parts)
            part->save;
    }
    
    void convert(Iconverter* Iconverterobj){
        for(auto part:parts)
            
    }
};


int main()
{
    Header header("Header", 1, "Document Title");
    Paragraph para("Paragraph", 2, "This is a sample paragraph.");

    WordDocument document;
    document.parts.push_back(&header);
    document.parts.push_back(&para);

    return 0;
}
