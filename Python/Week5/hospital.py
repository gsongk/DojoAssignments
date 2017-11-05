# Assignment: Hospital
# You're going to build a hospital with patients in it! Create a hospital class.
class patient(object):
    def __init__(self, name, allergies, bed_num):
        self.id = id
        self.name = name
        self.allergies = allergies
        self.bed_num = bed_num

    def display_patient(self):
        print 'Patient ID: ' + str(self.id)
        print 'Patient Name: ' + str(self.name)
        print 'Patient Allergies: ' + str(self.allergies)
        print 'Patient Bed Number: ' + str(self.bed_num)
        return self

class hospital(object):
    def __init__(self, hospital_name, capacity):
        self.patients = []
        self.hospital_name = hospital_name
        self.capacity = capacity
        self.beds = []
        for x in range(0, capacity):
            self.beds.append(False)
    
    def admit_patient(self, patient):
        if len(self.patients) >= self.capacity:
            print "Hospital is full."
        else:
            self.patients.append(patient)
            for index, bed in enumerate(self.beds):
                if bed == False:
                    patient.bed_num = index + 1
                    self.beds[index] = True
                    break
            print "Patient added."
        return self

    def discharge(self, patient):
        self.beds[patient.bed_num - 1] = False
        patient.bed_num= None
        for index, patient in enumerate(self.patients):
            if patient.id == patient.id:
                self.patients.pop(index)
                print 'Patient Discharged'
        return self

    def list_patients(self):
        self.count = 0
        print 'Name of Hospital: ' + str(self.hospital_name)
        print 'Capacity of Hospital: ' + str(self.capacity)
        for x in self.patients:
            self.count +=1
            x.display_patient()
        return self        

patient0 = patient('John Doe', 'Hypochondriac', 1)
patient1 = patient('Jane Doe', 'Unknown', 2)
patient2 = patient('John Carter', 'Seasonal', 3)

# patient0.display_patient()
# patient1.display_patient()
# patient2.display_patient()

hospital1 = hospital('Johns Clinic', 2)
hospital1.admit_patient(patient0).admit_patient(patient1).admit_patient(patient2)
hospital1.discharge(patient1).admit_patient(patient2).list_patients()
