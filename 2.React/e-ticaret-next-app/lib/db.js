import mongoose from "mongoose";

export const connection = async () =>{
    try {
        const uri = "mongodb://admin:pass@localhost:27017"; //docker ile ayağa kaldırırsak
        var result = await mongoose.connect(uri,{
            useNewUrlParser: true,
            useUnifiedTopology: true
        });
        console.log("MongoDb bağlantısı başarılı");
    } catch (error) {
        console.log(`MongoDb bağlantısı sırasında bir hatayla karşılaştık. Hata: ${error}`);
    }
}