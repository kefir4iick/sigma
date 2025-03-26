import SwiftUI

struct ContentView: View {
    @State private var statsinfo: String = "..."
    @State private var weatherinfo: String = "..."
    @State private var update: Bool = false
    @State private var loadstats: Bool = false
    @State private var loadweather: Bool = false

    var body: some View {
        ScrollView {
            VStack(spacing: 20) {
                CardView(title: "stats", content: statsinfo, load: loadstats)
                
                CardView(title: "weather", content: weatherinfo, load: loadweather)
                
                Button(action: {
                    update = true
                    fetchStats()
                    fetchWeather()
                    DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                        update = false
                    }
                }) {
                    HStack {
                        if update {
                            ProgressView()
                                .progressViewStyle(CircularProgressViewStyle(tint: .white))
                        }
                        Text(update ? "" : "Update")
                            .font(.headline)
                    }
                    .padding()
                    .frame(maxWidth: .infinity)
                    .background(Color.black)
                    .foregroundColor(.red)
                    .cornerRadius(10)
                    .shadow(color: Color.blue.opacity(0.3), radius: 10, x: 0, y: 5)
                }
                .padding(.horizontal)
                .disabled(loadstats || loadweather)
            }
            .padding()
        }
        .background(Color(.systemGroupedBackground).ignoresSafeArea())
    }
    
    func fetchStats() {
        loadstats = true
        guard let url = URL(string: "http://localhost:5230/stats") else { return }
        let session = URLSession(configuration: .ephemeral)
        session.dataTask(with: url) { data, response, error in
            if let data = data{
                do{
                    let decoded_data = try JSONDecoder().decode(Response1.self, from: data)
                    DispatchQueue.main.async {
                        loadstats = false
                        self.statsinfo = """
                    Time: \(decoded_data.uptime)
                    Requests: \(decoded_data.request_count)
                    Free memory: \(decoded_data.free_space) MB
                    RAM consumption: \(decoded_data.mem) MB
                    """
                    }
                }
                catch {
                    print("error")
                }
            }
        }.resume()
    }
    
    func fetchWeather() {
        loadweather = true
        guard let url = URL(string: "http://localhost:5230/weather") else { return }
        
        let session = URLSession(configuration: .ephemeral)
        session.dataTask(with: url) { data, response, error in
            if let data = data{
                do{
                    let decoded_data = try JSONDecoder().decode(Response2.self, from: data)
                    DispatchQueue.main.async {
                        loadweather = false
                        self.weatherinfo = "\(decoded_data.weather)"
                    }
                }
                catch {
                    print("error")
                }
            }
        }.resume()
    }
}

struct CardView: View {
    var title: String
    var content: String
    var load: Bool
    
    var body: some View {
        VStack(alignment: .leading, spacing: 10) {
            Text(title)
                .font(.title2)
                .fontWeight(.bold)
                .foregroundColor(.red)
            
            if load{
                ProgressView()
            }
            else{
                Text(content)
                    .font(.body)
                    .foregroundColor(.white)
                    .lineLimit(nil)
                    .fixedSize(horizontal: false, vertical: true)
            }
        }
        .padding()
        .frame(maxWidth: .infinity, alignment: .leading)
        .background(Color.black)
        .cornerRadius(15)
        .shadow(color: Color.black.opacity(0.1), radius: 10, x: 0, y: 5)
        .padding(.horizontal)
    }
}

struct Response1: Codable {
    let uptime: String
    let request_count: Int
    let free_space: Int
    let mem: Int
}

struct Response2: Codable {
    let weather: String
}


#Preview {
    ContentView()
}
